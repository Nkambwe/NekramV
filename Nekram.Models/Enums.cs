namespace Nekram.Models {
    public enum AppType {
        None,
        Standard,
        Enterprise,
        Professional,
        Ultimate   
    }

    /// <summary>
    /// Determined the type of user selected theme
    /// </summary>

    public enum Theme {

        /// <summary> 
        /// Default application theme. 
        /// </summary> 
        Default = 0,

        /// <summary> 
        /// Dark theme with purple highlight controls. 
        /// </summary>
        Purpledark = 1,

        /// <summary> 
        /// Dark theme with vlue highlight controls. 
        /// </summary>
        Bluedark = 2,

        /// <summary> 
        /// Dark theme with red highlight controls. 
        /// </summary>
        Reddark = 3,

        /// <summary> 
        /// Light theme with purple highlight controls. 
        /// </summary>
        Purplelight = 4,

        /// <summary> 
        /// Light theme with blue highlight controls. 
        /// </summary>
        Bluelight = 5,

        /// <summary> 
        /// Light theme with red highlight controls. 
        /// </summary>
        Redlight = 6
    }
}