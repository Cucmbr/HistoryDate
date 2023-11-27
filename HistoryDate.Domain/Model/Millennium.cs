namespace HistoryDate.Domain.Model
{
    public class Millennium : HistoryDate, IAnnoDomini
    {
        public int Value { get; set; }
        public bool AD { get; set; } = true;

        public override void CalcInterval()
        {
            //calculate interval
        }

        public override void FromJson()
        {

        }

        public override void ToJson()
        {

        }
    }
}
