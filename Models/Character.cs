using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebesAlk_v2_BodgalAttilaZoltan.Models
{
    public class Character
    {
        public int Id {  get; set; }
        [Range(8, 40, ErrorMessage = "The value must be between 8 and 40.")]
        public int Strength {  get; set; }
        [Range(8, 40, ErrorMessage = "The value must be between 8 and 40.")]
        public int Dexterity { get; set; }
        [Range(8, 40, ErrorMessage = "The value must be between 8 and 40.")]
        public int Constitution { get; set; }
        [Range(8, 40, ErrorMessage = "The value must be between 8 and 40.")]
        public int Inteligence { get; set; }
        [Range(8, 40, ErrorMessage = "The value must be between 8 and 40.")]
        public int Wisdom { get; set; }
        [Range(8, 40, ErrorMessage = "The value must be between 8 and 40.")]
        public int Charisma { get; set; }
        public CharacterClasses Class { get; set; }
        public string? Name { get; set; }
        [Range(1, 20, ErrorMessage = "The value must be between 1 and 20.")]
        public int Level { get; set; }
        public Races Race { get; set; }
        public bool AverageHP { get; set; }
        public int Maxhp { get; set; }
        public int Currenthp { get; set; }
        public string UserId { get; set; }

        [ValidateNever]
        public IdentityUser User { get; set; }
    }
}
