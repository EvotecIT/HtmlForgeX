namespace HtmlForgeX;
/// <summary>
///
/// Link: https://getbootstrap.com/docs/4.0/layout/grid/
/// </summary>
public enum TablerColumnNumber {
    Auto,
    None,
    /// <summary>
    /// The zero 'col-0' column
    /// </summary>
    Zero = 0,
    /// <summary>
    /// The one 'col-1' column
    /// </summary>
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Eleven,
    Twelve,

    /// <summary>
    /// The medium automatic column
    /// </summary>
    MediumAuto,
    /// <summary>
    /// The medium six 'col-md-6' column
    /// </summary>
    MediumSix,
    SmallSix,
    LargeSix,
    ExtraLargeSix,
    
    // Small breakpoint combinations
    SmallOne, SmallTwo, SmallThree, SmallFour, SmallFive, SmallSeven, SmallEight, SmallNine, SmallTen, SmallEleven, SmallTwelve,
    SmallAuto,
    
    // Medium breakpoint combinations  
    MediumOne, MediumTwo, MediumThree, MediumFour, MediumFive, MediumSeven, MediumEight, MediumNine, MediumTen, MediumEleven, MediumTwelve,
    
    // Large breakpoint combinations
    LargeOne, LargeTwo, LargeThree, LargeFour, LargeFive, LargeSeven, LargeEight, LargeNine, LargeTen, LargeEleven, LargeTwelve,
    LargeAuto,
    
    // Extra Large breakpoint combinations
    ExtraLargeOne, ExtraLargeTwo, ExtraLargeThree, ExtraLargeFour, ExtraLargeFive, ExtraLargeSeven, ExtraLargeEight, ExtraLargeNine, ExtraLargeTen, ExtraLargeEleven, ExtraLargeTwelve,
    ExtraLargeAuto,
    
    // Two-breakpoint responsive combinations
    SmallSixMediumFour, SmallSixMediumThree, SmallSixMediumTwo, SmallSixMediumOne,
    SmallFourMediumSix, SmallFourMediumThree, SmallFourMediumTwo,
    SmallThreeMediumSix, SmallThreeMediumFour, SmallThreeMediumTwo,
    SmallTwoMediumSix, SmallTwoMediumFour, SmallTwoMediumThree,
    
    SmallSixLargeThree, SmallSixLargeTwo, SmallSixLargeOne,
    SmallSixLargeFour,
    SmallFourLargeSix, SmallFourLargeThree, SmallFourLargeTwo,
    SmallThreeLargeSix, SmallThreeLargeFour, SmallThreeLargeTwo,
    
    MediumSixLargeThree, MediumSixLargeFour, MediumSixLargeTwo, MediumSixLargeOne,
    MediumFourLargeSix, MediumFourLargeThree, MediumFourLargeTwo,
    MediumThreeLargeSix, MediumThreeLargeFour, MediumThreeLargeTwo,
    
    // Three-breakpoint responsive combinations (most common Tabler patterns)
    SmallSixMediumSixLargeThree,
    SmallSixMediumSixLargeFour,
    SmallSixMediumFourLargeThree,
    SmallSixMediumFourLargeTwo,
    SmallSixMediumThreeLargeTwo,
    SmallFourMediumSixLargeThree,
    SmallFourMediumFourLargeThree,
    SmallFourMediumThreeLargeTwo,
    SmallThreeMediumSixLargeFour,
    SmallThreeMediumFourLargeThree,
    SmallThreeMediumThreeLargeTwo,
    
    // Extra Large combinations
    SmallSixMediumSixLargeThreeExtraLargeTwo,
    SmallSixMediumFourLargeThreeExtraLargeTwo,
    SmallFourMediumFourLargeThreeExtraLargeTwo
}

public static class ColumnNumberExtension {
/// <summary>
/// Method EnumToString.
/// </summary>
    public static string EnumToString(this TablerColumnNumber numberOfColumns) {
        switch (numberOfColumns) {
            case TablerColumnNumber.None:
                return "col";
            case TablerColumnNumber.Auto:
                return "col-auto";
            case TablerColumnNumber.MediumAuto:
                return "col-md-auto";
            case TablerColumnNumber.SmallSix:
                return "col-sm-6";
            case TablerColumnNumber.MediumSix:
                return "col-md-6";
            case TablerColumnNumber.LargeSix:
                return "col-lg-6";
            case TablerColumnNumber.ExtraLargeSix:
                return "col-xl-6";
            case TablerColumnNumber.MediumSixLargeThree:
                return "col-md-6 col-lg-3";
            case TablerColumnNumber.MediumSixLargeFour:
                return "col-md-6 col-lg-4";
            case TablerColumnNumber.SmallSixLargeFour:
                return "col-sm-6 col-lg-4";
            case TablerColumnNumber.SmallSixMediumSixLargeThree:
                return "col-sm-6 col-md-6 col-lg-3";
            case TablerColumnNumber.SmallSixMediumSixLargeFour:
                return "col-sm-6 col-md-6 col-lg-4";
                
            // Small breakpoints
            case TablerColumnNumber.SmallOne: return "col-sm-1";
            case TablerColumnNumber.SmallTwo: return "col-sm-2";
            case TablerColumnNumber.SmallThree: return "col-sm-3";
            case TablerColumnNumber.SmallFour: return "col-sm-4";
            case TablerColumnNumber.SmallFive: return "col-sm-5";
            case TablerColumnNumber.SmallSeven: return "col-sm-7";
            case TablerColumnNumber.SmallEight: return "col-sm-8";
            case TablerColumnNumber.SmallNine: return "col-sm-9";
            case TablerColumnNumber.SmallTen: return "col-sm-10";
            case TablerColumnNumber.SmallEleven: return "col-sm-11";
            case TablerColumnNumber.SmallTwelve: return "col-sm-12";
            case TablerColumnNumber.SmallAuto: return "col-sm-auto";
            
            // Medium breakpoints
            case TablerColumnNumber.MediumOne: return "col-md-1";
            case TablerColumnNumber.MediumTwo: return "col-md-2";
            case TablerColumnNumber.MediumThree: return "col-md-3";
            case TablerColumnNumber.MediumFour: return "col-md-4";
            case TablerColumnNumber.MediumFive: return "col-md-5";
            case TablerColumnNumber.MediumSeven: return "col-md-7";
            case TablerColumnNumber.MediumEight: return "col-md-8";
            case TablerColumnNumber.MediumNine: return "col-md-9";
            case TablerColumnNumber.MediumTen: return "col-md-10";
            case TablerColumnNumber.MediumEleven: return "col-md-11";
            case TablerColumnNumber.MediumTwelve: return "col-md-12";
            
            // Large breakpoints
            case TablerColumnNumber.LargeOne: return "col-lg-1";
            case TablerColumnNumber.LargeTwo: return "col-lg-2";
            case TablerColumnNumber.LargeThree: return "col-lg-3";
            case TablerColumnNumber.LargeFour: return "col-lg-4";
            case TablerColumnNumber.LargeFive: return "col-lg-5";
            case TablerColumnNumber.LargeSeven: return "col-lg-7";
            case TablerColumnNumber.LargeEight: return "col-lg-8";
            case TablerColumnNumber.LargeNine: return "col-lg-9";
            case TablerColumnNumber.LargeTen: return "col-lg-10";
            case TablerColumnNumber.LargeEleven: return "col-lg-11";
            case TablerColumnNumber.LargeTwelve: return "col-lg-12";
            case TablerColumnNumber.LargeAuto: return "col-lg-auto";
            
            // Extra Large breakpoints
            case TablerColumnNumber.ExtraLargeOne: return "col-xl-1";
            case TablerColumnNumber.ExtraLargeTwo: return "col-xl-2";
            case TablerColumnNumber.ExtraLargeThree: return "col-xl-3";
            case TablerColumnNumber.ExtraLargeFour: return "col-xl-4";
            case TablerColumnNumber.ExtraLargeFive: return "col-xl-5";
            case TablerColumnNumber.ExtraLargeSeven: return "col-xl-7";
            case TablerColumnNumber.ExtraLargeEight: return "col-xl-8";
            case TablerColumnNumber.ExtraLargeNine: return "col-xl-9";
            case TablerColumnNumber.ExtraLargeTen: return "col-xl-10";
            case TablerColumnNumber.ExtraLargeEleven: return "col-xl-11";
            case TablerColumnNumber.ExtraLargeTwelve: return "col-xl-12";
            case TablerColumnNumber.ExtraLargeAuto: return "col-xl-auto";
            
            // Two-breakpoint combinations
            case TablerColumnNumber.SmallSixMediumFour: return "col-sm-6 col-md-4";
            case TablerColumnNumber.SmallSixMediumThree: return "col-sm-6 col-md-3";
            case TablerColumnNumber.SmallSixMediumTwo: return "col-sm-6 col-md-2";
            case TablerColumnNumber.SmallSixMediumOne: return "col-sm-6 col-md-1";
            case TablerColumnNumber.SmallFourMediumSix: return "col-sm-4 col-md-6";
            case TablerColumnNumber.SmallFourMediumThree: return "col-sm-4 col-md-3";
            case TablerColumnNumber.SmallFourMediumTwo: return "col-sm-4 col-md-2";
            case TablerColumnNumber.SmallThreeMediumSix: return "col-sm-3 col-md-6";
            case TablerColumnNumber.SmallThreeMediumFour: return "col-sm-3 col-md-4";
            case TablerColumnNumber.SmallThreeMediumTwo: return "col-sm-3 col-md-2";
            case TablerColumnNumber.SmallTwoMediumSix: return "col-sm-2 col-md-6";
            case TablerColumnNumber.SmallTwoMediumFour: return "col-sm-2 col-md-4";
            case TablerColumnNumber.SmallTwoMediumThree: return "col-sm-2 col-md-3";
            
            case TablerColumnNumber.SmallSixLargeThree: return "col-sm-6 col-lg-3";
            case TablerColumnNumber.SmallSixLargeTwo: return "col-sm-6 col-lg-2";
            case TablerColumnNumber.SmallSixLargeOne: return "col-sm-6 col-lg-1";
            case TablerColumnNumber.SmallFourLargeSix: return "col-sm-4 col-lg-6";
            case TablerColumnNumber.SmallFourLargeThree: return "col-sm-4 col-lg-3";
            case TablerColumnNumber.SmallFourLargeTwo: return "col-sm-4 col-lg-2";
            case TablerColumnNumber.SmallThreeLargeSix: return "col-sm-3 col-lg-6";
            case TablerColumnNumber.SmallThreeLargeFour: return "col-sm-3 col-lg-4";
            case TablerColumnNumber.SmallThreeLargeTwo: return "col-sm-3 col-lg-2";
            
            case TablerColumnNumber.MediumSixLargeTwo: return "col-md-6 col-lg-2";
            case TablerColumnNumber.MediumSixLargeOne: return "col-md-6 col-lg-1";
            case TablerColumnNumber.MediumFourLargeSix: return "col-md-4 col-lg-6";
            case TablerColumnNumber.MediumFourLargeThree: return "col-md-4 col-lg-3";
            case TablerColumnNumber.MediumFourLargeTwo: return "col-md-4 col-lg-2";
            case TablerColumnNumber.MediumThreeLargeSix: return "col-md-3 col-lg-6";
            case TablerColumnNumber.MediumThreeLargeFour: return "col-md-3 col-lg-4";
            case TablerColumnNumber.MediumThreeLargeTwo: return "col-md-3 col-lg-2";
            
            // Three-breakpoint combinations
            case TablerColumnNumber.SmallSixMediumFourLargeThree: return "col-sm-6 col-md-4 col-lg-3";
            case TablerColumnNumber.SmallSixMediumFourLargeTwo: return "col-sm-6 col-md-4 col-lg-2";
            case TablerColumnNumber.SmallSixMediumThreeLargeTwo: return "col-sm-6 col-md-3 col-lg-2";
            case TablerColumnNumber.SmallFourMediumSixLargeThree: return "col-sm-4 col-md-6 col-lg-3";
            case TablerColumnNumber.SmallFourMediumFourLargeThree: return "col-sm-4 col-md-4 col-lg-3";
            case TablerColumnNumber.SmallFourMediumThreeLargeTwo: return "col-sm-4 col-md-3 col-lg-2";
            case TablerColumnNumber.SmallThreeMediumSixLargeFour: return "col-sm-3 col-md-6 col-lg-4";
            case TablerColumnNumber.SmallThreeMediumFourLargeThree: return "col-sm-3 col-md-4 col-lg-3";
            case TablerColumnNumber.SmallThreeMediumThreeLargeTwo: return "col-sm-3 col-md-3 col-lg-2";
            
            // Four-breakpoint combinations
            case TablerColumnNumber.SmallSixMediumSixLargeThreeExtraLargeTwo: return "col-sm-6 col-md-6 col-lg-3 col-xl-2";
            case TablerColumnNumber.SmallSixMediumFourLargeThreeExtraLargeTwo: return "col-sm-6 col-md-4 col-lg-3 col-xl-2";
            case TablerColumnNumber.SmallFourMediumFourLargeThreeExtraLargeTwo: return "col-sm-4 col-md-4 col-lg-3 col-xl-2";
            default:
                return $"col-{(int)numberOfColumns}";
        }
    }
}