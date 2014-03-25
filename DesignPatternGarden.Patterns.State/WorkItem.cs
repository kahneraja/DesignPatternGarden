namespace DesignPatternGarden.Patterns.State
{
    public class WorkItem : ICommands
    {

        private string _State;
        private ICommands stateCommands;

        public int Id { get; set; }
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;

                // Potentially loaded dynamically...
                if (_State == "Proposed")
                    stateCommands = new States.Proposed(this);
                if (_State == "Active")
                    stateCommands = new States.Active(this);
                if (_State == "Resolved")
                    stateCommands = new States.Resolved(this);
                if (_State == "Closed")
                    stateCommands = new States.Closed(this);
            }
        }
        public string Title { get; set; }
        public string Description { get; set; }

        public WorkItem()
        {
            Id = 1;
            State = "Proposed";
        }

        public void Edit(string title, string desc)
        {
            stateCommands.Edit(title, desc);
        }

        public void SetState(string state)
        {
            stateCommands.SetState(state);
        }
    }
}
