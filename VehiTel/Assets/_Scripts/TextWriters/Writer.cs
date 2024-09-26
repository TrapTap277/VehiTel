namespace _Scripts.TextWriters
{
    public abstract class Writer
    {
        protected DataWriter DataWriter;

        protected void Write(DataType dataType, string text)
        {
            DataWriter.SetText(dataType);
            DataWriter.Write(text);
        }
    }
}