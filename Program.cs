using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.IO;         // for making files



class Program
{

   // async and await - async marks a method as asynchronous, enabling the use of await     
   // while await pauses the execution of the method until the awaited asynchronous operation completes.
  
  

// ntfy 


   public static async Task SendNtfyNotification (string title ,string message )
    {
           
           using (var httpClient = new HttpClient())
         {
            var topic = "kavya269";

            var url = $"https://ntfy.sh/{topic}" ;

           

            var content = new StringContent(message , Encoding.UTF8,"text/plain");

            try
            {
               // // The rest of the code execution is paused by await until this async task is completed

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


               

if (i>=60)
{
   // // The rest of the code execution is paused by await until this async task of sending notification is completed
   

   Console.WriteLine("pass");
             await SendNtfyNotification("Result", $"congratulations you are passed with average of : {i} ") ;
        Console.WriteLine("Notification sent.");


// creat file
//WriteAllText - creats file and writes the content in it
//ReadAllText - reads the content from file and stores in variable Content
// through writeline it then prints the content it read on terminal

 string  filePath="result.pdf";
          File.WriteAllText("result.pdf", $"your marks \n english {english} \n maths {math} \n science {science} \n congratulations you are passed with average of : {i}");
            string Content = File.ReadAllText(filePath);
        Console.WriteLine("File Content:\n" + Content);


}

                
               else if(i<=60)
        {
             Console.WriteLine("fail");
             await SendNtfyNotification("Result", $"you are failed , your average is {i}");
        Console.WriteLine("Notification sent.");

        string  filePath="result.pdf";
          File.WriteAllText("result.pdf", $" your marks \n english {english} \n maths {math} \n science {science} \n failed with average of : {i}");
            string Content = File.ReadAllText(filePath);
        Console.WriteLine("File Content:\n" + Content);


        }


   }
        
        
        
    }




           
         