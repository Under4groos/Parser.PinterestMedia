using Parser.PinterestMediaLib;
using Parser.PinterestMediaLib.Structures;

string URL = "https://ru.pinterest.com/pin/362539838770181124/";

//     client.DefaultRequestHeaders.Add("cookie", "csrftoken=bab2asd21fbca0f20asd1231229792bab4fd6; _auth=1; _pinterest_sess=TWc9PSZPRTNGRnZIZXZNeTJsVVZDbWMrN1NyY3hsZlQrWU1hY05wZHRUU3l0TUVJSXNRUXZhcmlyNWE3QVdVQ2NzRlpFY1NPeHJEbFdhVnVCVzhZeVAvYXlqMk91Q28yallwVzk2NmNocEl6ZWdMZ3g2NS80ZjVmUXhIeTNwUUh1cHFiNStYSFdwZXZUZlJkdEdDT0pGTXF1cUZpclFasdsad12MlVIalBCcGwyT0pYZWU2VVhNeHl4dW44VTJmRk1OS1JJam9YSy9jbGJaeXJhK3MzT1RNT3QzRnowOEtrMVNWazZNNDBLK29YTzNsRjBuQ280SjdJK1hOSzdobXM5cVQ0THpNb0IwaAS28zTWpvamNndit3N0F1QTRHOUxQNTdCc0xyUVBOZmkwV1VjRVNGZ3lvOEFpasdasd12cVMvMWNRTU1CSzJDU2pOcDhgdfghWGc5Q2Z5NWQ2NnBjhgjdaskUEF2OEpMUlAycTFHVjFJUjR2Mk94SEh3S1pFQ3Nmc0pESnRkV3VDaUJVVFVBPT0mNnFKSktsTklJR1V1VjlRSDF5b25vU2kwMENVPQ==; __Secure-s_a=dHRndGozWG5DdASDWh2T3Z2YTZ0WkpublNWASD123TNNdHdSYzJpWlRSUzB2ajd4NnFjUHdmASDASDA3YjYxVDRLdGE4YTNUVDAzWmx0TzJvN29OcmFrZHlrQjYwc0NMWVVqOHFFcUlya2p4N1M0NzhIcDFQTXdoRkRpME1UY01hYzBVaURGb0QwOWhKOGlqSU1rcFFvbGpsaTJVY3I3QW41U0daT3BuWkFUSmZtZk16Qy82VjFFS2VVQnVQcG9WMzRUOTRhMitCK3RETmRYTEllbUtjL1NqaEpJdUdSeTZNaHZzaEV6T3pFdmNpUGIzeU9hL1ljR0VqTXlNQjAzNFNXMDNYS0Y1L1RkRUc5VGU2eTJnS01Jb0VhNzl4cTBnZTgzMnM9JmRCSEU5TFltMWRBYmZyQVhCU0Y3TTlPTFFPQT0=; _b=\"AXqtrfv7HuASD213*872139IVY0sq3xAdv5aONMrx468GTZCdaP6pSIbJMFnWoVyHjk=\"; ar_debug=1; ar_debug=1; cm_sub=denied; _routing_id=\"12321ASDASD8-e4DDDe2-42D52-b3b9-d10A6a447d4d0\"; sessionFunnelEventLogged=1; _pinterest_referrer=https://www.google.com/");

string file_cookie = "file_cookie.TXT";

if (File.Exists(file_cookie))
{
    file_cookie = File.ReadAllText(file_cookie);
    if (file_cookie == string.Empty)
        return;
}
else
{
    File.WriteAllText(file_cookie, "");
    return;
}

using (PinParser client = new PinParser())
{
    client.DefaultHeaders();
    client.DefaultRequestHeaders.Add("cookie", file_cookie);
    client.Parse(URL);

    foreach (Video item in client.LinksVideo)
    {
        Console.WriteLine(item);
    }
}
Console.ReadKey();