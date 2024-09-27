# Parser.PinterestMedia

### Парстер сайта pinterest.com
Получаем ссылки на видео слудующим образом:

```C#
using Parser.PinterestMediaLib;
using Parser.PinterestMediaLib.Structures;

string URL = "https://ru.pinterest.com/pin/362539838770181124/";
string file_cookie = "file_cookie.TXT";

// Читаем данные с куки с файла
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

// Сам парсер. 
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

```


В файле "file_cookie.TXT" должны лежать куки. 
```txt
 client.DefaultRequestHeaders.Add("cookie""csrftoken=bab2asd21fbca0f20asd1231229792bab4fd6;);
```