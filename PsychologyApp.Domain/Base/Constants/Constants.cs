using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyApp.Domain.Base.Constants;

public class Constants
{
    /// <summary>Fixed recipient for feedback and technical error reports; the user reviews and sends each email.</summary>
    public const string ReviewEmailAddress = "m.a.sukhih@yandex.ru";


    public const string AliceUrl = "https://alice.yandex.ru/";
    public const int SmallBaseTimeout = 5000;
    public const int MiddleBaseTimeout = 10000;
    public const int LargeBaseTimeout = 15000;
}

