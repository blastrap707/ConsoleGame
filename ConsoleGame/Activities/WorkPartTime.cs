namespace ConsoleGame.Activities
{
    internal class WorkPartTime : AbstractAction
    {
        protected override string OptionName => "夜のアルバイトする";

        protected override int TimeCost => 5;
        protected override int Earnings { get; set; }

        protected override string RuleExplanation()
        {
            throw new System.NotImplementedException();
        }

        /*protected override int MakeMoney(PayBackPlanner paybackrecord, SampleItem item)
{
throw new NotImplementedException();
}

protected override bool HasNumberInput => false;
protected override int Income { get; set; }

protected override int Expenditure { get; set; }

protected override int Hours { get; set; }

protected int MakeMoney(PayBackPlanner paybackrecord)
{
throw new NotImplementedException();
}*/

        protected override void GetLatestCondition(PayBackPlanner condition)
        {
        }
    }
}