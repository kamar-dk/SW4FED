using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

//
// This class represents a single baby name, including ranking info for 1900..2000.
// The data was collected by the United States Social Security Administration.  For 
// more info, see: http://www.ssa.gov/OACT/babynames/.
//
// Prof Joe Hummel
// June 2006
//
public class BabyName
{
    //
    // Data fields: name, and ranks for 1900..2000.
    //
    private string m_name;
    private int[] m_ranks;  // 11 ranks: 1900, 1910, ..., 2000

    //
    // Properties
    //
    public string Name
    {
        get { return this.m_name; }
    }

    //
    // Constructor: initializes baby name object based on a rank string, which contains
    //   12 values: the name, followed by 11 rankings (1900, 1910, ..., 2000).
    //
    public BabyName(string nameAndRankings)
    {
        string[] tokens;
        char[] separators = { ' ' };

        // break line into 12 tokens: name and 11 rankings:
        tokens = nameAndRankings.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        this.m_name = tokens[0];
        this.m_ranks = new int[11];
        for (int i = 0; i < 11; i++)
            this.m_ranks[i] = int.Parse(tokens[i + 1]);
    }

    //
    // Returns the rank of this name for the given year 1900, 1910, 1920, ..., 2000.
    //
    public int Rank(int year)
    {
        int index;

        index = (year - 1900) / 10;
        if (index < 0 || index > 10)
            throw new System.ArgumentException("Invalid year, must be 1900, 1910, ..., 2000");

        return this.m_ranks[index];
    }

    //
    // Returns the average ranking across the century for this  name.
    //
    public int AverageRank()
    {
        int sum;

        //
        // NOTE: a rank of 0 doesn't rank in the popularity, so we treat that as a
        // ranking of 2500 to generate a more accurate average.
        //
        sum = 0;
        for (int i = 0; i < this.m_ranks.Length; i++)
        {
            if (this.m_ranks[i] == 0)
                sum = sum + 2500;
            else
                sum = sum + this.m_ranks[i];
        }//for

        return sum / this.m_ranks.Length;
    }

    //
    // Returns the trend (i.e. average change) over the last 20 years (1980..2000)
    //   of the century for this  name; this is a positive value if the name is
    //   becoming more popular, a negative value if the name is becoming less popular,
    //   and zero if the name didn't change in popularity or the change isn't
    //   consistent (increase then decrease, or vice versa).
    //
    public int Trend()
    {
        int r1980, r1990, r2000, diff80s, diff90s;

        //
        // NOTE: a rank of 0 doesn't rank in the popularity, so we treat that as a
        // ranking of 2500 to generate a more accurate average.
        //
        r1980 = (this.m_ranks[8] == 0) ? 2500 : this.m_ranks[8];  // 1980
        r1990 = (this.m_ranks[9] == 0) ? 2500 : this.m_ranks[9];  // 1990
        r2000 = (this.m_ranks[10] == 0) ? 2500 : this.m_ranks[10]; // 2000

        //
        // Note that the HIGHER the ranking, the LESS popular the name; e.g. 1 is the 
        // most popular name that decade.
        //
        diff80s = r1980 - r1990;
        diff90s = r1990 - r2000;

        if (diff80s < 0 && diff90s > 0)  // inconsistent
            return 0;
        else if (diff80s > 0 && diff90s < 0)  // inconsistent
            return 0;
        else  // a trend:
            return (diff80s + diff90s) / 2;
    }

}//class
