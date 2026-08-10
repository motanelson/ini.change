using System.Diagnostics;

class inifiles


{
    static String Mains = "main"; static String Value = "ok";

    static void Writes()
    {

        Console.WriteLine(Value);


    }
    public static String[] sets(String[] ss,String s,String ss1) 
    {
        String s1 = "";
        String[] h = { };
        int counts = 0;
        Array.Sort(ss);

        foreach (String s2 in ss)
        {
            s1 = s2.Trim();
            h = s1.Split("=");
            if (h.Length > 1)
            {

                if (h[0].Trim() == s.Trim())
                {
                    ss[counts] = h[0] + "=" + ss1;
                    return ss;
                }

            }
            counts++;
        }

        Array.Resize(ref ss, ss.Length + 1);
        ss[ss.Length - 1] = s + "=" + ss1;
        
        return ss;



    }
    public static String gets(String[] ss, String s) 
    {
        String s1 = "";
        String[] h = { };
        Array.Sort(ss);

        foreach (String s2 in ss)
        {
            s1 = s2.Trim();
            h = s1.Split("=");
            if (h.Length > 1) 
            {

                if (h[0].Trim() == s.Trim()) return h[1];
            
            }
            
        }
        return "";
    }
    public static void saves(String[] ss, String files)
    {
        String[] s = ss;
        String sss = "";
        String[] h = { };
        String s1 = "";
        Mains = "main";
        Array.Sort(ss);
        foreach (String s2 in ss)
        {
            s1 = s2.Trim();
            if (s1 != "")
            {
                h = s1.Split("/");
                if (h.Length > 1)
                {
                    if (Mains != h[0]) sss = sss + "[" + h[0] + "]\n";
                    Mains = h[0];
                    sss = sss + h[1] + "\n";
                }

            }

        }
        
        File.WriteAllText(files, sss);


    }
    public static void Debusgs(String[] ss)
    {
        foreach (String s2 in ss)
        {

            Value = s2;
            Writes();
        }



    }
    public static String[] initLoad(String files)
    {
        int l1 = 0;
        int l2 = 0;
        String[] s = { };
        String[] ss = { };
        s = File.ReadAllLines(files);
        foreach (String s2 in s)

        {
            s2.Trim();
            Value = s2;
            l1 = s2.IndexOf('[') + 1;
            l2 = s2.IndexOf("]");
            if (!(l1 < 1))
            {
                if (l2 > -1) Mains = s2.Substring(l1, l2 - l1).Trim().Replace(" ", "_");
                else
                {
                    Value = "error:";
                    Writes();


                }
            }
            else
            {
                if (s2 != "")
                {
                    Value = Mains + "/" + s2.Trim();
                    Array.Resize(ref ss, ss.Length + 1);
                    ss[ss.Length - 1] = Value;
                }
            }

        }

        Array.Sort(ss);
        return ss;
    }



}






class savetini

{
    static void Writes(String Value)
    {

        Console.WriteLine(Value);


    }
    public static void Main(String[] argv)
    {


        int lens = argv.Length;
        String s = "";
        String[] ss = { };
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        if (lens > 0)

        {
            s = argv[0];
            ss = inifiles.initLoad(s);
        }
        else
            Console.WriteLine("give me file name ");


        Writes(inifiles.gets(ss,"main/main"));
        ss=inifiles.sets(ss, "main/x", "xxx");
        Writes("------------------------------------");
        inifiles.Debusgs(ss);
        inifiles.saves(ss, "init.ini");

    }

}
