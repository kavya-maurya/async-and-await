using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

class Program
{
   public static async Task SendNtfyNotification (string title ,string message )
    {
           
           using (var httpClient = new HttpClient())
         {
            var topic = "kavya269";
            var url = $"https://ntfy.sh/{topic}" ;

           

            var content = new StringContent(message , Encoding.UTF8,"text/plain");

            try
            {
               
                   var response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

            }
catch(Exception ex)
            {
                    Console.WriteLine(ex);
            }
         }
    }

             static async Task Main()
    {

       Console.Write("Enter your marks in english : ");
        int english = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your marks in maths : ");
          int math = Convert.ToInt32(Console.ReadLine());
   
        Console.Write("Enter your marks  in science : ");
        int science = Convert.ToInt32(Console.ReadLine());

        int i= (math+science+english)/3;

        if  (math>0 && math<=100 && science>0 && science<=100 && english>0 && english<=100)
        {
      
            
            Console.WriteLine($"your average score is {i}");

                if(  i >= 90)
                     {
                        Console.WriteLine(" your performance according to your average is ---->Excellent");
                     }

                    else if(  i >= 80)
                    {Console.WriteLine(" your performance ---->good");
                    }

                     else if(  i >= 70)
                    {Console.WriteLine(" your performance ---->fair");
                    }

                     else if(  i >= 60)
                    {Console.WriteLine(" your performance ---->average");
                    }

                     else 
                    {Console.WriteLine("your performance ---->poor");
                    }


               }  

if (i>=60)
{
   Console.WriteLine("pass");
             await SendNtfyNotification("Result", $"congratulations you are passed with average of : {i} ") ;
        Console.WriteLine("Notification sent.");
}
                
               else if(i<=60)
        {
             Console.WriteLine("fail");
             await SendNtfyNotification("Result", $"you are failed , your average is {i}");
        Console.WriteLine("Notification sent.");
        }


   }
        
        
        
    }




           
         