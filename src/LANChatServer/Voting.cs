using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;


class Voting
{
    public Dictionary<string, int> Options = new Dictionary<string, int>();
    public Dictionary<string, string> Voter = new Dictionary<string, string>();
    
    public Boolean is_running = false;
    

    public Voting()
    {

    }
    

    public void Stop()
    {
        is_running = false;
    }


    public void Start()
    {
        is_running = true;
    }


    public String GetVotingResult()
    {
        String result = "";
        int max = -1;
        // finding MAX
        foreach (var pair in Options)
        {
            string key = pair.Key;
            int value = pair.Value;
           
            if (value > max)
            {
                max = value;
                result = key;
            }
        }
        // now check if others had the same
        foreach (var pair in Options)
        {
            string key = pair.Key;
            int value = pair.Value;

            if (value == max)
            {
                result = String.Join(";",result);
            }
        }
        return result;
    }
      


}
