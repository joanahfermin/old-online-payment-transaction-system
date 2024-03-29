﻿using SampleRPT1.FORMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SampleRPT1
{
    /// <summary>
    /// Global variable objects.
    /// </summary>
    internal class GlobalVariables
    {
        // constant variables for the entire quarter of rpt.
        public const string FIRST_QUARTER = "1-1";
        public const string FIRSTQUARTER_TO_SECONDQUARTER = "1-2";
        public const string FIRSTQUARTER_TO_THIRDQUARTER = "1-3";
        public const string FULL_YEAR = "1-4";

        public const string SECOND_QUARTER = "2-2";
        public const string SECONDQUARTER_TO_THIRDQUARTER = "2-3";
        public const string SECONDQUARTER_TO_FOURTHDQUARTER = "2-4";

        public const string THIRD_QUARTER = "3-3";
        public const string THIRDQUARTER_TO_FOURTHQUARTER = "3-4";

        public const string FOURTHQUARTER_TO_FOURTHQUARTER = "4-4";

        public static string[] ALL_QUARTER = { FIRST_QUARTER, FIRSTQUARTER_TO_SECONDQUARTER, FIRSTQUARTER_TO_THIRDQUARTER, FULL_YEAR,
            SECOND_QUARTER, SECONDQUARTER_TO_THIRDQUARTER, SECONDQUARTER_TO_FOURTHDQUARTER, THIRD_QUARTER, THIRDQUARTER_TO_FOURTHQUARTER,
            FOURTHQUARTER_TO_FOURTHQUARTER };

        public const string NO_RETRIEVED_NAME = "****NO RECORD FOUND IN I.T DATABASE****";

        public const string BUSINESS_NEW = "NEW BUSINESS";
        public const string BUSINESS_RENEWAL = "RENEWAL BUSINESS";

        public static string[] BUSINESS_TYPE = { BUSINESS_NEW, BUSINESS_RENEWAL };


    }
}
