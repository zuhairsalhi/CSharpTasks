using Task15.App;

List<Contact> contacts = new List<Contact>();

contacts.Add(new Contact(
    "Zuhair",
    "0791234567",
    "zuhair@gmail.com"
));

contacts.Add(new Contact(
    "Ahmad",
    "0789876543",
    "ahmad@gmail.com"
));

contacts.Add(new Contact(
    "Omar",
    "0775555555",
    "omar@gmail.com"
));

Console.WriteLine(" Contacts ");

foreach (Contact contact in contacts)
{
    Console.WriteLine(contact);
}
Console.WriteLine();
Console.WriteLine("Contact Groups");

Dictionary<string, List<Contact>> groups = new Dictionary<string, List<Contact>>();

groups["Family"] = new List<Contact>
{
    contacts[0],
    contacts[1]
};

groups["Work"] = new List<Contact>
{
    contacts[2]
};

foreach (var group in groups)
{
    Console.WriteLine($"Group: {group.Key}");

    foreach (Contact contact in group.Value)
    {
        Console.WriteLine($"  {contact.Name}");
    }
}
Console.WriteLine();
Console.WriteLine("Stack");

Stack<string> recentActions = new Stack<string>();

recentActions.Push("Added Zuhair");
recentActions.Push("Added Ahmad");
recentActions.Push("Added Omar");

Console.WriteLine($"Last action: {recentActions.Pop()}");
Console.WriteLine($"Last action: {recentActions.Pop()}");

Console.WriteLine();
Console.WriteLine("Queue");

Queue<string> waitingList = new Queue<string>();

waitingList.Enqueue("Zuhair");
waitingList.Enqueue("Ahmad");
waitingList.Enqueue("Omar");

Console.WriteLine($"Next: {waitingList.Dequeue()}");
Console.WriteLine($"Next: {waitingList.Dequeue()}");

Console.WriteLine();
Console.WriteLine("HashSet");

HashSet<string> phoneNumbers = new HashSet<string>();

phoneNumbers.Add("0791234567");
phoneNumbers.Add("0789876543");
phoneNumbers.Add("0791234567");

foreach (string phone in phoneNumbers)
{
    Console.WriteLine(phone);
}
Console.WriteLine();
Console.WriteLine("LinkedList");

LinkedList<Contact> contactList = new LinkedList<Contact>();

contactList.AddLast(contacts[0]);
contactList.AddLast(contacts[1]);
contactList.AddLast(contacts[2]);

Console.WriteLine("Original list:");

foreach (Contact contact in contactList)
{
    Console.WriteLine(contact.Name);
}