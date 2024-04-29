using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;
using System.Text;


internal class Program
{
    const string username = "andriizarichniuk5@ukr.net";
    const string password = "Sk7moJfNrHTSWkz6";
    private static void Main(string[] args)
    {
        /*    var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("Andrii Zarichniuk",username));
            msg.To.Add(new MailboxAddress("Test user", "rijefa5938@dxice.com"));
            msg.Subject = "Hello World!";
            msg.Importance = MessageImportance.High;
                msg.Body = new TextPart()
                {
                    Text = @" Hey Jon
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tempor commodo ullamcorper a lacus vestibulum sed arcu non odio. Pellentesque elit ullamcorper dignissim cras tincidunt lobortis feugiat. Suspendisse interdum consectetur libero id faucibus nisl tincidunt. Gravida quis blandit turpis cursus in hac habitasse. Id velit ut tortor pretium viverra suspendisse potenti nullam ac. Dui id ornare arcu odio ut sem nulla. Pharetra massa massa ultricies mi quis hendrerit dolor magna. Proin sed libero enim sed. Elit pellentesque habitant morbi tristique senectus."

            };

                using(var client = new SmtpClient())
                {
                    client.Connect("smtp.ukr.net", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
                    client.Authenticate(username, password);
                    client.Send(msg);
                }*/
        Console.OutputEncoding = Encoding.UTF8;
        using (var client = new ImapClient())
        {
            client.Connect("imap.ukr.net",993,MailKit.Security.SecureSocketOptions.SslOnConnect);
            client.Authenticate(username,password);

            var folders = client.GetFolders(client.PersonalNamespaces[0]);
            foreach (var folder in folders)
            {
                Console.WriteLine("Folder : " + folder.Name);
            }

            var folder_ = client.GetFolder(MailKit.SpecialFolder.Sent);
            folder_.Open(MailKit.FolderAccess.ReadWrite);
            var id = folder_.Search(SearchQuery.All).LastOrDefault();

            var mail = folder_.GetMessage(id);
            Console.WriteLine(mail.Date + " " + mail.Subject + "\n" + mail.TextBody);

            /*  folder_.MoveTo(id,client.GetFolder(MailKit.SpecialFolder.Junk));

              folder_.Expunge();*/

           // folder_.AddFlags(id,MessageFlags.Deleted,true);

            //folder_.Expunge();
          
        }
    }
}