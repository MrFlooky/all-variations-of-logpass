HashSet<string> WriteToHashSet(string fileName) =>
    new(File.ReadLines(fileName));

void WriteHashsetToFile(string filename, HashSet<string> lines, bool append) {
    using StreamWriter sw = new(filename, append);
    foreach (string line in lines)
        sw.WriteLine(line);
}

Console.WriteLine("Drop file with login:password:");
string path = Console.ReadLine().Replace("\"", "");
if (!File.Exists(path))
    Console.WriteLine("File not found");

HashSet<string> logins = new();
HashSet<string> passwords = new();

HashSet<string> lines = WriteToHashSet(path);

foreach (string line in lines) {
    string[] split = line.Split(':');
    if (!logins.Contains(split[0]))
        logins.Add(split[0]);
    if (!passwords.Contains(split[1]))
        passwords.Add(split[1]);
}
long i = 0;
lines.Clear();
foreach (string login in logins)
    foreach (string password in passwords) {
        lines.Add($"{login}:{password}");
        ++i;
    }

WriteHashsetToFile("result.txt", lines, false);
Console.WriteLine($"Completed! Lines in result.txt: {i}");
Console.ReadLine();