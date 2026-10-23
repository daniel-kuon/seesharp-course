using System;

public class FizzBuzz {
    public static string Wort(int zahl) {
        if (zahl % 15 == 0)
            return "FizzBuzz";
        else if (zahl % 3 == 0)
            return "Fizz";
        else if (zahl % 5 == 0)
            return "Buzz";
        else
            return "" + zahl;
    }

    public static string Folge(int bis) {
        string folge = Wort(1);
        for (int i = 2; i <= bis; i++)
            folge += " " + Wort(i);
        return folge;
    }
}
