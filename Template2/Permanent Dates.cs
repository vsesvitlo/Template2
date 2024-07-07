namespace Template2
{
    public static class Table
    {
        public static Dictionary<int, Params> sleepTable;

        static Table()
        {
            sleepTable = new Dictionary<int, Params>();
            sleepTable[0] = new Params(4, 5, 5, 6, 16, 19, new TimeSpan(0, 40, 0), new TimeSpan(1, 0, 0), 4, 14);
            sleepTable[1] = new Params(4, 5, 8, 10, 14, 17, new TimeSpan(0, 50, 0), new TimeSpan(1, 15, 0), 5, 8);
            sleepTable[2] = new Params(4, 5, 8, 10, 14, 17, new TimeSpan(1, 0, 0), new TimeSpan(1, 20, 0), 6, 7);
            sleepTable[3] = new Params(4, 4, 10, 11, 15, 17, new TimeSpan(1, 20, 0), new TimeSpan(1, 35, 0), 5, 7);
            sleepTable[4] = new Params(3, 4, 10, 12, 14, 17, new TimeSpan(1, 3, 0), new TimeSpan(2, 0, 0), 3, 5);
            sleepTable[5] = new Params(2, 4, 10, 12, 13, 16, new TimeSpan(1, 45, 0), new TimeSpan(2, 15, 0), 3, 4);
            sleepTable[6] = new Params(2, 3, 10, 12, 13, 16, new TimeSpan(2, 15, 0), new TimeSpan(2, 30, 0), 2, 4);
            sleepTable[7] = new Params(2, 3, 10, 12, 13, 15, new TimeSpan(2, 45, 0), new TimeSpan(3, 0, 0), 2, 4);
            sleepTable[8] = new Params(2, 3, 10, 12, 13, 15, new TimeSpan(3, 0, 0), new TimeSpan(4, 0, 0), 2, 4);
            sleepTable[9] = new Params(2, 2, 10, 12, 12, 15, new TimeSpan(3, 10, 0), new TimeSpan(4, 10, 0), 2, 3);
            sleepTable[10] = new Params(2, 2, 10, 12, 12, 15, new TimeSpan(3, 20, 0), new TimeSpan(4, 20, 0), 2, 3);
            sleepTable[11] = new Params(2, 2, 10, 12, 12, 15, new TimeSpan(3, 30, 0), new TimeSpan(4, 30, 0), 2, 3);
            sleepTable[12] = new Params(1, 2, 10, 12, 12, 14, new TimeSpan(3, 30, 0), new TimeSpan(4, 30, 0), 2, 3);
            sleepTable[13] = new Params(1, 2, 10, 12, 12, 14, new TimeSpan(3, 30, 0), new TimeSpan(5, 0, 0), 2, 3);
            sleepTable[16] = new Params(0, 1, 10, 11, 11, 14, new TimeSpan(5, 0, 0), new TimeSpan(6, 0, 0), 1, 3);
            sleepTable[36] = new Params(0, 1, 10, 11, 11, 13, new TimeSpan(5, 0, 0), new TimeSpan(6, 0, 0), 1, 2);
            sleepTable[48] = new Params(0, 1, 10, 11, 11, 13, new TimeSpan(6, 0, 0), new TimeSpan(6, 0, 0), 1, 2);
            sleepTable[49] = new Params(0, 1, 9.5, 11, 10, 13, new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), 1, 2);
            sleepTable[84] = new Params(0, 0, 10, 11, 10, 11, new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), 0, 0);
            sleepTable[120] = new Params(0, 0, 9, 11, 9, 11, new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), 0, 0);
            sleepTable[144] = new Params(0, 0, 9, 10, 9, 10, new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0), 0, 0);

        }
    }
    public record Params
    {
        public readonly int minDaySleeps; // мінімальна кількість снів в день
        public readonly int maxDaySleeps;

        public readonly double minNightSleep; // мінімальна кількість годин сну вночі
        public readonly double maxNightSleep;

        public readonly double minRecomendedSleep; // мінімальна кількість годин сну загальна
        public readonly double maxRecomendedSleep;

        public readonly TimeSpan minNotSleepInterval; // мінімальний інтервал не спання дитини
        public readonly TimeSpan maxNotSleepInterval;

        public readonly int minDayTimeSleepPeriod;
        public readonly int maxDayTimeSleepPeriod;

        public Params(int minDaySleeps, int maxDaySleeps,
            double minNightSleep, double maxNightSleep,
            double minRecomendedSleep, double maxRecomendedSleep,
            TimeSpan minNotSleepInterval, TimeSpan maxNotSleepInterval, 
            int minDayTimeSleepPeriod, int maxDayTimeSleepPeriod)
        {
            this.minDaySleeps = minDaySleeps;
            this.maxDaySleeps = maxDaySleeps;
            this.minNightSleep = minNightSleep;
            this.maxNightSleep = maxNightSleep;
            this.minRecomendedSleep = minRecomendedSleep;
            this.maxRecomendedSleep = maxRecomendedSleep;
            this.minNotSleepInterval = minNotSleepInterval;
            this.maxNotSleepInterval = maxNotSleepInterval;
            this.minDayTimeSleepPeriod = minDayTimeSleepPeriod;
            this.maxDayTimeSleepPeriod = maxDayTimeSleepPeriod;

        }
    }

}
