using System.ComponentModel.DataAnnotations;

namespace BoardGameLogger.Models
{
    public enum GenreType
    {
        [Display(Name = "")]
        None,
        Abstract,
        Strategy,
        [Display(Name = "Co-op")]
        CoOp,
        [Display(Name = "Hidden Identity")]
        HiddenIdentity
    }
}
