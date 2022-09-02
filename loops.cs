using System;

public class loops
{
    bool equality;
    //check if input is equal 
    Console.WriteLine("first word");
       String input1 = Console.ReadLine();
        Console.WriteLine("second word");
        String input2 = Console.ReadLine();

        if (input1 == input2)
        {
            for (int i = 0; i < input1.Length; i++)
            {

                if (input1[i] == input2[i])
                    return equality = true;

                else
                    return equality = false;
            }
        }
        else
            Console.WriteLine("not Equal");
    
}
