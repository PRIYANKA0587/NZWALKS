using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Models.DTO
{
    public class WalkUpdateRequest
    {
       
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public double Length { get; set; }

        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }


        
        
    }
}
