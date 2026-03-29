
namespace NotedApp.Api.Models.Entities
{
    
    public class Note{
    
   public int Note_id {get; set;}
   public String Title {get; set;}

   public String? Content {get; set;}
   public DateTime CreateAt {get; set;}
   public DateOnly UpdateAt {get; set;}
   public int User_id {get; set;}
}

}
