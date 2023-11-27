namespace EncryptedDiaryApp;

internal class Program
{
    static List<string> dairyDocuments { get; set; } = new List<string>();

    const string path = "C:\\Proje\\Dairy.txt";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Yeni kayıt ekle");
            Console.WriteLine("2. Kayıtları listele");
            Console.WriteLine("3. Tüm kayıtları sil");
            Console.WriteLine("4. Çıkış");

            ConsoleKeyInfo choice = Console.ReadKey();
            Console.Clear();

            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    AddNewDocument(path);
                    break;
                case ConsoleKey.D2:
                    DocumentList(path); 
                    break;
                case ConsoleKey.D3:
                    DeleteAllDocuments(path);
                    break;
                case ConsoleKey.D4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void AddNewDocument(string path)
    {
        StreamWriter writer = new StreamWriter(path, true);
        Console.WriteLine("Günlük kaydınızı ekleyin:");
        string newDocument = $"{DateTime.Now}\n{Console.ReadLine()}";
        dairyDocuments.Add(newDocument);
        writer.WriteLine(newDocument);
        writer.Close();
        Console.WriteLine("Kayıt eklendi.");
        Console.ReadLine();
    }

    static void DocumentList(string path)
    {
        if(File.Exists(path))
        {
            Console.WriteLine("Günlük Kayıtlar:\n");

            string[] documents = File.ReadAllLines(path);

            foreach (var document in documents)
            {
                Console.WriteLine(document);
            }
        }
        else 
        {
            Console.WriteLine("Herhangi bir kayıt bulunamadı."); 
        }
        
        Console.ReadLine() ;
    }   

        static void DeleteAllDocuments(string path)
    {
        Console.WriteLine("Tüm kayıtları silmek istediğinize emin misiniz? (E/H)");

        if (Console.ReadLine().ToUpper() == "E")
        {

            File.Delete(path);
            Console.WriteLine("Tüm kayıtlar silindi.");
        }
        else
        {
            Console.WriteLine("İşlem iptal edildi.");
        }

        Console.ReadLine();
    }
}

    