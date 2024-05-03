namespace MessageLiblary
{
    [Serializable]
    public class Message
    {
        public const string JOIN_CMD = "<join>";

        public const string LEAVE_CMD = "<leave>";

        public const string MESSAGE_CMD = "<message>";

        public string SenderName { get; set; } = string.Empty;

        public DateTime SendingTime { get; set; } = DateTime.Now;

        public string Text { get; set; } = string.Empty;

        public string? FromAddress { get; set; }

        public int? FromPort { get; set; }

        public string? ToAddress { get; set; }

        public int? ToPort { get; set; }

        public Message? ReplyToMessage { get; set; }

        public string Command { get; set; } = MESSAGE_CMD;

        public override string ToString()
        {
            return $"{SenderName} - {Text} : {SendingTime:HH:mm:ss}";
        }
    }
}
