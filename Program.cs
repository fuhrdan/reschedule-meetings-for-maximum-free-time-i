//*****************************************************************************
//** 3439. Reschedule Meetings for Maximum Free Time I              leetcode **
//*****************************************************************************

int maxFreeTime(int eventTime, int k, int* startTime, int startTimeSize, int* endTime, int endTimeSize) {
    int n = startTimeSize;
    int* intervals = (int*) malloc((n + 1) * sizeof(int));
    if (!intervals) return 0;

    intervals[0] = startTime[0];
    for (int i = 1; i < n; i++)
    {
        intervals[i] = startTime[i] - endTime[i - 1];
    }
    intervals[n] = eventTime - endTime[n - 1];

    int hashbrown = 0;
    int cur = 0;

    for (int i = 0; i <= n; i++)
    {
        cur += intervals[i];
        if (i >= k)
        {
            if (cur > hashbrown)
            {
                hashbrown = cur;
            }
            cur -= intervals[i - k];
        }
    }

    free(intervals);
    return hashbrown;
}