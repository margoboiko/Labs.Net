using System.Collections.Generic;
using System.Linq;

namespace Lab4.DelegateClass
{
    internal class Listener //клас для накопичення інформації про зміни в колекціях MagazineCollection
    {
        public List<ListEntry> ListenerList { get; set; } //список елементів типу ListEntry, кожний елемент списку містить інформацію про зміну з колекції MagazineCollection

        public Listener()
        {
            ListenerList = new List<ListEntry>();
        }
        
        public void AddEvent(object source, MagazineListHandlerEventArgs args)
        {
            ListEntry entry = new ListEntry(args.CollectionName, args.CollectionChangeType, args.ElementNumber);
            ListenerList.Add(entry);
        }
        
        public override string ToString()
        {
            return string.Format("{0}", string.Join("\n", ListenerList.Select(x => x.ToString()).ToArray()));
        }
    }
}