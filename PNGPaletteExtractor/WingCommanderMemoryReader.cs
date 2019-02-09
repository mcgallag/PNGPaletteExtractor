using System;
using System.Drawing;
using Memory;

namespace WingCommanderMemoryReader
{
    /// <summary>
    /// internal representation of which game to read from, used for indexing some variables
    /// </summary>
    enum GameMode
    {
        WC1, WC2
    };

    /// <summary>
    /// Interface for reading memory values from DOSBox
    /// </summary>
    class MemoryReader
    {
        // used for interfacing with DOSBox
        private Mem m;
        private int pid;

        // to track which game we are playing, and therefore memory offsets
        private readonly GameMode game;

        /// <summary>
        /// true if successfully hooked to the DOSBox process
        /// </summary>
        public bool OpenProc { get; private set; } = false;

        /// <summary>
        /// base memory address for DOSBox RAM
        /// </summary>
        private const string memoryBase = "0x01D3A1A0";

        /// <summary>
        /// memory offset for player callsign
        /// </summary>
        private string CallSignOffset
        {
            get => callSignOffsets[(int)game];
        }
        private readonly string[] callSignOffsets = {
            "0x1E040", "0x27C9B"
        };

        /// <summary>
        /// memory offset for wingman callsign
        /// </summary>
        private string WingmanCallsignOffset
        {
            get => wingmanCallsignOffsets[(int)game];
        }
        private readonly string[] wingmanCallsignOffsets =
        {
            "", "0x2AC86"
        };

        /// <summary>
        /// memory offset for wingman kills
        /// </summary>
        private string WingmanKillsOffset
        {
            get => wingmanKillsOffsets[(int)game];
        }
        private readonly string[] wingmanKillsOffsets =
        {
            "", "0x302d2"
        };

        /// <summary>
        /// memory offset for player first name
        /// </summary>
        private string PlayerFirstNameOffset
        {
            get => playerFirstNameOffset[(int)game];
        }
        private readonly string[] playerFirstNameOffset =
        {
            "0x1E032", "0x2CCB0"
        };

        /// <summary>
        /// memory offset for player last name
        /// </summary>
        private string PlayerLastNameOffset
        {
            get => playerLastNameOffset[(int)game];
        }
        private readonly string[] playerLastNameOffset =
        {
            "", "0x2CC98"
        };

        /// <summary>
        /// memory offset for player's sortie count
        /// </summary>
        private string SortiesOffset
        {
            get => sortiesOffsets[(int)game];
        }
        private readonly string[] sortiesOffsets =
        {
            "0x1E052", "0x27CAA"
        };

        /// <summary>
        /// memory offset for player's total kills
        /// </summary>
        private string TotalKillsOffset
        {
            get
            {
                return totalKillsOffsets[(int)game];
            }
        }
        private readonly string[] totalKillsOffsets =
        {
            "0x1E054", "0x27CAC"
        };

        /// <summary>
        /// memory offset for player's in-mission kills
        /// </summary>
        private string CurrentKillsOffset
        {
            get => currentKillsOffsets[(int)game];
        }
        private readonly string[] currentKillsOffsets =
        {
            "0x1E402", "0x302C8"
        };

        /// <summary>
        /// memory offset for player's rank value
        /// </summary>
        private string RankOffset
        {
            get => rankOffsets[(int)game];
        }
        private readonly string[] rankOffsets =
        {
            "0x1E050", ""
        };

        /// <summary>
        /// memory offset for player's ship kps
        /// </summary>
        private string SetKpsOffset
        {
            get => setKpsOffsets[(int)game];
        }
        private readonly string[] setKpsOffsets =
        {
            "0x1FFE7", "0x295FF"
        };

        /// <summary>
        /// memory offset for player's remaining afterburner fuel
        /// </summary>
        private const string remainingFuelOffsetWC1 = "0x2045C"; //WC1

        /// <summary>
        /// memory offset for player's ship name
        /// </summary>
        private string PlayerShipOffset
        {
            get => playerShipOffset[(int)game];
        }
        private readonly string[] playerShipOffset =
        {
            "", "0x24AFC"
        };

        /// <summary>
        /// used to properly calcuate number of player kills, set when we enter Halcyon's debriefing and cleared at mission start
        /// </summary>
        public bool DebriefMode = false;

        /// <summary>
        /// instantiates a new MemoryReader
        /// </summary>
        public MemoryReader(GameMode game)
        {
            this.game = game;
            m = new Mem();

            SetPID();
        }

        /// <summary>
        /// sets and returns the process id of DOSBox if available
        /// </summary>
        /// <returns></returns>
        public int SetPID()
        {
            pid = m.getProcIDFromName("DOSBox");
            return pid;
        }

        /// <summary>
        /// attaches the memory reader interface to DOSBox throws DOSBoxMemoryException on error
        /// </summary>
        public void Attach()
        {
            // refresh PID just to be safe
            if (OpenProc == false)
            {
                SetPID();
                if (pid == 0)
                {
                    throw new DOSBoxMemoryException("getProcIDFromName returned 0. Are you sure DOSBox.exe is running?");
                }

                OpenProc = m.OpenProcess(pid);
                if (OpenProc == false)
                {
                    throw new DOSBoxMemoryException("OpenProcess returned false. Are administrative priveleges acquried?");
                }
            }
        }

        /// <summary>
        /// detaches the memory reader interface from DOSBox
        /// </summary>
        public void Detach()
        {
            if (OpenProc)
            {
                m.closeProcess();
                OpenProc = false;
            }
        }

        /// <summary>
        /// gets current ship index for Ship VDU layout
        /// </summary>
        private int GetPlayerShipIndex()
        {
            switch (GetPlayerShipName())
            {
                case "Ferret":
                    return 0;
                case "Broadsword":
                    return 1;
                case "Rapier":
                    return 2;
                case "Epee":
                    return 3;
                case "Sabre":
                    return 4;
            }
            return -1;
        }

        /// <summary>
        /// top-left pixel boundary of the Right VDU
        /// </summary>
        private Point RightVduOffset
        {
            get => rightVduOffsetPoints[GetPlayerShipIndex()];
        }
        private readonly Point[] rightVduOffsetPoints =
        {
            new Point(122, 98),     // ferret
            new Point(240, 132),    // broadsword
            new Point(245, 97),     // rapier
            new Point(188, 91),     // epee
            new Point(240, 133)     // sabre
        };

        /// <summary>
        /// top-left pixel boundary of the Left VDU
        /// </summary>
        private Point LeftVduOffset
        {
            get => leftVduOffsetPoints[GetPlayerShipIndex()];
        }
        private readonly Point[] leftVduOffsetPoints =
        {
            new Point(0, 0),    // ferret
            new Point(4, 132),  // broadsword
            new Point(0, 97),   // rapier
            new Point(55, 91),  // epee
            new Point(4, 133)   // sabre
        };

        /// <summary>
        /// pixel size of the VDU
        /// </summary>
        private Size VduSize
        {
            // BUG - throws exception when no valid ship name
            get => vduSize[GetPlayerShipIndex()];
        }
        private readonly Size[] vduSize =
        {
            new Size(75, 65),   // ferret
            new Size(75, 65),   // broadsword
            new Size(75, 70),   // rapier
            new Size(75, 65),   // epee
            new Size(75, 65)    // sabre
        };

        /// <summary>
        /// Generates bitmaps for VGA buffer and VDUs.
        /// If a ship only has one VDU, the odd (left) VDU will be empty
        /// </summary>
        /// <param name="palette">palette to draw colors from</param>
        /// <returns>Array of 3 bitmaps (VGA buffer, left VDU, right VDU)</returns>
        public Bitmap[] GetDisplayAndVDUs(Color[] palette)
        {
            int shipindex = GetPlayerShipIndex();
            Size vdusize = VduSize;
            Bitmap[] images = {
                new Bitmap(320, 200),
                new Bitmap(vdusize.Width, vdusize.Height),
                new Bitmap(vdusize.Width, vdusize.Height)
            };
            Point offsetLeft = LeftVduOffset;
            Point offsetRight = RightVduOffset;

            // get the current VGA buffer
            byte[] buffer = GetVGABuffer();

            for (int i = 0; i < buffer.Length; i++)
            {
                // write directly to the bitmap representing the VGA buffer
                images[0].SetPixel(i % 320, i / 320, palette[buffer[i]]);

                // if we are within bounds of the right VDU, then write to it
                if (i / 320 >= offsetRight.Y && (i / 320 < (offsetRight.Y + vdusize.Height)))
                {
                    if (i % 320 >= offsetRight.X && (i % 320) < (offsetRight.X + vdusize.Width))
                    {
                        images[1].SetPixel((i % 320) - offsetRight.X, (i / 320) - offsetRight.Y, palette[buffer[i]]);
                    }
                }

                // if we are within bounds of the left VDU, then write to it
                if (offsetLeft.Y != 0 && i / 320 >= offsetLeft.Y && (i / 320 < (offsetLeft.Y + vdusize.Height)))
                {
                    if (i % 320 >= offsetLeft.X && (i % 320) < (offsetLeft.X + vdusize.Width))
                    {
                        images[2].SetPixel((i % 320) - offsetLeft.X, (i / 320) - offsetLeft.Y, palette[buffer[i]]);
                    }
                }
            }

            return images;
        }

        /// <summary>
        /// Fetches the VGA buffer from DOSBox's memory
        /// </summary>
        /// <returns>64000 byte VGA buffer array</returns>
        public byte[] GetVGABuffer()
        {
            if (OpenProc)
            {
                string addr = "0x1EEBEF0";
                return m.readBytes(addr, 320 * 200);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches set kps value from DOSBox memory
        /// </summary>
        /// <returns>set kps</returns>
        public int GetSetKPS()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + SetKpsOffset;
                return m.readByte(addr) * 10;
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches player first name from DOSBox memory
        /// </summary>
        /// <returns>player name</returns>
        public string GetPlayerFirstName()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + PlayerFirstNameOffset;
                return m.readString(addr, length: 14);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches player last name from DOSBox memory
        /// </summary>
        /// <returns>player name, empty string if game doesn't support it</returns>
        public string GetPlayerLastName()
        {
            if (OpenProc)
            {
                // WC1 is first-name only
                if (game == GameMode.WC1) return "";

                string addr = memoryBase + "," + PlayerLastNameOffset;
                return m.readString(addr, length: 14);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches player callsign from DOSBox memory
        /// </summary>
        /// <returns>player callsign</returns>
        public string GetPlayerCallsign()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + CallSignOffset;
                return m.readString(addr, length: 12);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches wingman callsign from DOSBox memory
        /// </summary>
        /// <returns>wingman callsign</returns>
        public string GetWingmanCallsign()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + WingmanCallsignOffset;
                return m.readString(addr).TrimStart();
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches the name of the player's current ship
        /// </summary>
        /// <returns>player ship model</returns>
        public string GetPlayerShipName()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + PlayerShipOffset;
                return m.readString(addr);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches player sortie count from DOSBox memory
        /// </summary>
        /// <returns>player sortie count</returns>
        public int GetSorties()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + SortiesOffset;
                return m.read2Byte(addr);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches player killboard kills from DOSBox memory
        /// </summary>
        /// <returns>player killboard kill count</returns>
        public int GetTotalPlayerKills()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + TotalKillsOffset;
                return m.read2Byte(addr);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches wingman in-mission kills from DOSBox memory
        /// </summary>
        /// <returns>wingman in-mission kills</returns>
        public int GetWingmanKills()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + WingmanKillsOffset;
                return m.readByte(addr);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }


        /// <summary>
        /// fetches player in-mission kills from DOSBox memory
        /// </summary>
        /// <returns>player in-mission kill count</returns>
        public int GetCurrentKills()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + CurrentKillsOffset;
                return m.read2Byte(addr);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }

        /// <summary>
        /// fetches player rank value from DOSBox memory
        /// </summary>
        /// <returns>player rank value</returns>
        public int GetRank()
        {
            if (OpenProc)
            {
                string addr = memoryBase + "," + RankOffset;
                return m.read2Byte(addr);
            }
            throw new DOSBoxMemoryException("Must hook to DOSBox process before reading memory.");
        }
    }


    [Serializable]
    public class DOSBoxMemoryException : Exception
    {
        public DOSBoxMemoryException() { }
        public DOSBoxMemoryException(string message) : base(message) { }
        public DOSBoxMemoryException(string message, Exception inner) : base(message, inner) { }
        protected DOSBoxMemoryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
