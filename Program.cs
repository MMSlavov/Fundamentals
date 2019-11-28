using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Regex_fund
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string username = Console.ReadLine();

            while (true)
            {
                string[] com = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (com[0] == "Sign") break; 
                switch (com[0])
                {
                    case "Case":
                        var chrArr = username.ToCharArray();
                        if (com[1] == "upper")
                        {
                            username = string.Join("", chrArr.Select(l => l.ToString().ToUpper()));
                        }
                        else if(com[1] == "lower")
                            username = string.Join("", chrArr.Select(l => l.ToString().ToLower()));
                        Console.WriteLine(username);
                        break;
                    case "Reverse":
                        int start = int.Parse(com[1]);
                        int end = int.Parse(com[2]);
                        if (start >= username.Length || start < 0 ||
                            end >= username.Length || end < 0) break;
                        int count = end - start + 1;
                        var revArr = username.Substring(start, count).ToCharArray();
                        Array.Reverse(revArr);
                        Console.WriteLine(string.Join("", revArr));
                        break;
                    case "Cut":
                        if(!username.Contains(com[1]))
                        {
                            Console.WriteLine($"The word {username} doesn't contain {com[1]}.");
                        }
                        else
                        {
                            username = username.Replace(com[1], "");
                            Console.WriteLine(username);
                        }
                        break;
                    case "Replace":
                        username = username.Replace(com[1], "*");
                        Console.WriteLine(username);
                        break;
                    case "Check":
                        if (username.Contains(com[1])) Console.WriteLine("Valid");
                        else
                            Console.WriteLine($"Your username must contain {com[1]}.");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string com = Console.ReadLine();*/

            /*var mes0 = new List<string>();
            var mes = new List<string>();
            string com = Console.ReadLine();
            if (com.Contains('<') && com.Contains('>'))
            {
                mes0.AddRange(Console.ReadLine().Split('>'));
                mes.AddRange(Console.ReadLine().Split('<'));
            }
            else
            {
                Console.WriteLine("Try another password!");
                continue;
            }

            if (mes.Count != 2 && mes0.Count != 2 && mes0[0] != mes[1])
            {
                Console.WriteLine("Try another password!");
                continue;
            }
            string[] pass = mes[0].Split('|');
            if (pass.All(gr => gr.Length == 3) &&
                pass.Length == 4 &&
                pass[0].All(s => char.IsDigit(s)) &&
                pass[1].All(s => char.IsLower(s)) &&
                pass[2].All(s => char.IsUpper(s)) &&
                pass[3].All(s => s != '<' && s != '>'))
            {
                Console.WriteLine("Password: " + string.Join("", pass));
            }
            else 
                Console.WriteLine("Try another password!");

            Regex rx = new Regex(@"\S[^<>]+>\d{3}\|[a-z]{3}\|[A-Z]{3}\|[^<>]{3}<\S[^<>]+");
            if (!rx.IsMatch(com))
            {
                Console.WriteLine("Try another password!");
                continue;
            }
            string[] mes0 = com.Split('>');
            string[] mes = mes0[1].Split('<');
            if (mes.Length != 2 && mes0.Length != 2 && mes0[0] != mes[1])
            {
                Console.WriteLine("Try another password!");
                continue;
            }
            Console.WriteLine("Password: " + string.Join("", mes[0].Split('|')));

            }
            MatchCollection names = Regex.Matches(Console.ReadLine(), @"\+359(?<separator>[ ,-])2\1\d{3}\1\d{4}\b");

            Console.WriteLine(string.Join(", ", names));
            var names = new List<string>();
            double totSum = 0;
            while (true)
            {
                string com = Console.ReadLine();
                if (com == "Purchase") break;
                Match m = Regex.Match(com, @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quant>\d+)", RegexOptions.IgnoreCase);
                if (!m.Success) continue;
                names.Add(m.Groups["name"].Value);
                double sum = double.Parse(m.Groups["price"].Value);
                int pc = int.Parse(m.Groups["quant"].Value);
                totSum += sum * pc;
            }
            Console.WriteLine("Bought furniture:");
            if (names.Count > 0) names.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"Total money spend: {totSum:f2}");
            var sw = new Stopwatch();
            sw.Start();
            var racers = Console.ReadLine().Split(", ").ToDictionary(r => r, v => 0);
            Regex ptrn = new Regex(@"([A-Za-z])|(\d)");

            while (true)
            {
                var com = Console.ReadLine();
                if (com == "end of race") break;
                var m = ptrn.Matches(com);
                var dis = 0;
                var name = "";
                foreach (Match sym in m)
                {
                    //Console.WriteLine(sym);
                    if (char.IsDigit(Convert.ToChar(sym.ToString())))
                    {
                        dis += Convert.ToInt32(sym.ToString());
                    }
                    else
                    {
                        name += sym;
                    }
                }
                //Console.WriteLine(name);
                //Console.WriteLine(dis);
                //var dis = ptrn.Matches(com).Select(x => int.Parse(x.ToString())).Sum();
                if (racers.ContainsKey(name))
                {
                    racers[name] += dis;
                }
            }
            int count = 0;
            string[] ord = new string[3] { "1st","2nd","3rd"};
            foreach (var item in racers.OrderByDescending(d => d.Value).Take(3))
            {
                Console.WriteLine($"{ord[count]} place: {item.Key}");
                count++;
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            double tot = 0;
            while (true)
            {
                string com = Console.ReadLine();
                if (com == "end of shift") break;
                var match = Regex.Match(com, @"%([A-Z][a-z]+)%[^\|\$\%\.]*<(\w+)>[^\|\$\%\.]*\|(\d+)\|[^\|\$\%\.\d]*((?:\d+\.\d+)|(?:\d+))\$", RegexOptions.None);
                if (!match.Success) continue;
                double sum = int.Parse(match.Groups[3].Value) * double.Parse(match.Groups[4].Value);
                Console.WriteLine($"{match.Groups[1]}: {match.Groups[2]} - {sum:f2}");
                tot += sum;
            }
            Console.WriteLine($"Total income: {tot:f2}");

            int n = int.Parse(Console.ReadLine());
            var keyPtrn = new Regex(@"[star]", RegexOptions.IgnoreCase);
            var atkPlanets = new List<string>();
            var destPlanets = new List<string>();


            for (int i = 0; i < n; i++)
            {
                string com = Console.ReadLine();
                int key = keyPtrn.Matches(com).Count;
                var mes = string.Join("", com.Select(s => (char)(s - key)).ToArray());
                var match = Regex.Match(mes, @"\@([A-Za-z]+)[^\@\-\!\:\>]*:(\d+)[^\@\-\!\:\>]*!(A|D)![^\@\-\!\:\>]*->(\d+)", RegexOptions.None);
                if (!match.Success) continue;
                if (match.Groups[3].Value == "A")
                {
                    atkPlanets.Add(match.Groups[1].Value);
                }
                else
                    destPlanets.Add(match.Groups[1].Value);
            }
            Console.WriteLine($"Attacked planets: {atkPlanets.Count}");
            atkPlanets = atkPlanets.OrderBy(pl => pl).ToList();
            atkPlanets.ForEach(pl => Console.WriteLine("-> " + pl));
            Console.WriteLine($"Destroyed planets: {destPlanets.Count}");
            destPlanets = destPlanets.OrderBy(pl => pl).ToList();
            destPlanets.ForEach(pl => Console.WriteLine("-> " + pl));

            var demons = Console.ReadLine().Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            demons = demons.OrderBy(x => x).ToList();
            foreach (var item in demons)
            {
                Console.WriteLine($"{item} - {GetHealth(item)} health, {GetDamage(item):f2} damage ");
            }

            var emails = Regex.Matches(Console.ReadLine(), @"(?<=[ ])[\d+A-Za-z]+([._-]?[\d+A-Za-z]+)+@[A-Za-z]+[-]?[A-Za-z]+(\.[A-Za-z]+[-]?[A-Za-z]+)+");
            foreach (Match email in emails)
            {
                Console.WriteLine(email);
            }

            var tickets = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - {GetPrice(ticket)}");
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string com = Console.ReadLine();
                var ptrn = new Regex(@"^([^>]+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$");
                var match = ptrn.Match(com);
                if (!match.Success)
                {
                    Console.WriteLine("Try another password!");
                    continue;
                }
                else
                    Console.WriteLine("Password: " + match.Groups[2] + match.Groups[3] + match.Groups[4] + match.Groups[5]);
            }

            var followers = new Dictionary<string, int[]>();
            while (true)
            {
                string[] com = Console.ReadLine().Split(new char[] { ':',' '}, StringSplitOptions.RemoveEmptyEntries);
                if (com[0] == "Log" && com[1] == "out") break;
                switch (com[0])
                {
                    case "New":
                        if (!followers.ContainsKey(com[2]))
                        {
                            followers.Add(com[2], new int[] { 0, 0});
                        }
                        break;
                    case "Like":
                        if (!followers.ContainsKey(com[1]))
                        {
                            followers.Add(com[1], new int[] { 0, 0 });
                        }
                        followers[com[1]][0] += int.Parse(com[2]);
                        break;
                    case "Comment":
                        if (!followers.ContainsKey(com[1]))
                        {
                            followers.Add(com[1], new int[] { 0, 0 });
                        }
                        followers[com[1]][1]++;
                        break;
                    case "Blocked":
                        if (!followers.ContainsKey(com[1]))
                            Console.WriteLine($"{com[1]} doesn't exist.");
                        else
                            followers.Remove(com[1]);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            Console.WriteLine($"{followers.Count} followers");
            foreach (var fl in followers.OrderByDescending(f => f.Value[0]).ThenBy(f => f.Key))
            {
                Console.WriteLine($"{fl.Key}: {fl.Value.Sum()}");
            }

            string str = Console.ReadLine();

            while (true)
            {
                string[] com = Console.ReadLine().Split();
                if (com[0] == "End") break;
                switch (com[0])
                {
                    case "Translate":
                        str = str.Replace(com[1], com[2]);
                        Console.WriteLine(str);
                        break;
                    case "Includes":
                        Console.WriteLine(str.Contains(com[1]));
                        break;
                    case "Start":
                        Console.WriteLine(str.StartsWith(com[1]));
                        break;
                    case "Lowercase":
                        str = str.ToLower();
                        Console.WriteLine(str);
                        break;
                    case "FindIndex":
                        Console.WriteLine(str.LastIndexOf(char.Parse(com[1])));
                        break;
                    case "Remove":
                        str = str.Remove(int.Parse(com[1]), int.Parse(com[2]));
                        Console.WriteLine(str);
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var match = Regex.Match(input, @"^(\$|\%)([A-Z][a-z]{3,})\1: (?:\[(\d+)\]\|){3}$");
                if (match.Success)
                {
                    Console.WriteLine($"{match.Groups[2]}: {string.Join("",Regex.Matches(input, @"\d+").Select(m => (char)int.Parse(m.ToString())))}");
                }
                else
                    Console.WriteLine("Valid message not found!");
            }*/
            var users = new Dictionary<string, int[]>();
            int cap = int.Parse(Console.ReadLine());

            while (true)
            {
                var com = Console.ReadLine().Split("=");
                if (com[0] == "Statistics") break;
                switch (com[0])
                {
                    case "Add":
                        if (!users.ContainsKey(com[1]))
                        {
                            users.Add(com[1], new int[] { int.Parse(com[2]), int.Parse(com[3]) });
                        }
                        break;
                    case "Message":
                        if (users.ContainsKey(com[1]) && users.ContainsKey(com[2]))
                        {
                            users[com[1]][0]++;
                            users[com[2]][1]++;
                            if (users[com[1]].Sum() >= cap)
                            {
                                Console.WriteLine($"{com[1]} reached the capacity!");
                                users.Remove(com[1]);
                            }
                            else if (users[com[2]].Sum() >= cap)
                            {
                                Console.WriteLine($"{com[2]} reached the capacity!");
                                users.Remove(com[2]);
                            }
                        }
                        break;
                    case "Empty":
                        if (users.ContainsKey(com[1]))
                        {
                            users.Remove(com[1]);
                        }
                        else if (com[1] == "All")
                        {
                            users.Clear();
                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            Console.WriteLine($"Users count: {users.Count}");
            foreach (var user in users.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value.Sum()}");
            }
        }
        static string GetPrice(string ticket)
        {
            string half1 = Regex.Match(ticket.Substring(0, 10), @"[@$#^]+").ToString();
            string half2 = Regex.Match(ticket.Substring(10, 10), @"[@$#^]+").ToString();
            if (half1 == half2 && half1 != "")
            {
                if (half1.Length == 10) return $"10{half1[0]} Jackpot!";
                else return $"{half1.Length}{half1[0]}";
            }
            else return "no match";
        }
        static double GetDamage(string name)
        {
            var damPtrn = new Regex(@"(\+\d+\.\d+)|(\-\d+\.\d+)|(\d+\.\d+)|(\d+)|(\-\d+)|(\+\d+)");
            var damage = damPtrn.Matches(name).Select(d => double.Parse(d.ToString())).Sum();
            var match = Regex.Matches(name, @"[*\/]").Select(x => char.Parse(x.ToString())).ToArray();
            foreach (var sym in match)
            {
                if (sym == '*')
                {
                    damage *= 2;
                }
                else
                    damage /= 2;
            }
            return damage;
        }
        static int GetHealth(string name)
        {
            var hpPtrn = new Regex(@"[^\d\+\-\*\/\.]");
            var health = hpPtrn.Matches(name).Select(hp => (int)char.Parse(hp.ToString())).Sum();
            return health;
        }
    }
}
