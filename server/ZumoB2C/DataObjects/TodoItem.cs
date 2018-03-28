using Microsoft.Azure.Mobile.Server;

namespace ZumoB2C.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}