var ds = new SimpleStack<double>(10);
ds.Push(3.141);
ds.Push(2.718);
while (ds.Count > 0)
    Console.WriteLine("Oben lag: " + ds.Pop());

var ss = new SimpleStack<string>();
ss.Push("eins");
Console.WriteLine(ss.Peek());
