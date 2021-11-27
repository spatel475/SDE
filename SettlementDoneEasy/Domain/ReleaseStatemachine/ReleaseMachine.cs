using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Stateless;
using Stateless.Graph;

namespace SDE_Server.Domain.ReleaseStatemachine
{
    public class ReleaseMachine
    {
        [JsonIgnore]
        public StateMachine<ReleaseState, ReleaseTrigger> Statemachine { get; set; }
        [JsonIgnore]
        public Dictionary<ReleaseTrigger, ReleaseStateTrigger> Triggers { get; set; }

        [JsonConstructor]
        public ReleaseMachine(string state)
        {
            Configure((ReleaseState)Convert.ToInt32(state));
        }

        public ReleaseMachine()
        {
            Configure();
        }


        private void OnTransition(StateMachine<ReleaseState, ReleaseTrigger>.Transition obj)
        {

        }

        private ReleaseContext GetStateContext()
        {
            throw new NotImplementedException();
            return null;
        }

        private ReleaseGlobalContext GetGlobalContext()
        {
            throw new NotImplementedException();
            return null;
        }

        private void Configure(ReleaseState state = ReleaseState.P1_Draft)
        {
            Triggers = new Dictionary<ReleaseTrigger, ReleaseStateTrigger>() {
                {ReleaseTrigger.Edit, new ReleaseStateTrigger((int)ReleaseTrigger.Edit, "Edit", "All information on the document can be changed during this state.") },
                {ReleaseTrigger.Accept, new ReleaseStateTrigger((int)ReleaseTrigger.Accept, "Accept", "The document has been accepted as valid by the party that received it.") },
                {ReleaseTrigger.Archive, new ReleaseStateTrigger((int)ReleaseTrigger.Archive, "Archived", "The document is archived and can no longer be edited or updated.") },
                {ReleaseTrigger.Reject, new ReleaseStateTrigger((int)ReleaseTrigger.Reject, "Reject", "The document has been rejected as invalid by the party that recieved it.") },
                {ReleaseTrigger.Save, new ReleaseStateTrigger((int)ReleaseTrigger.Save, "Save", "The document's changes have been saved.") },
                {ReleaseTrigger.Transmit, new ReleaseStateTrigger((int)ReleaseTrigger.Transmit, "Transmit", "The document has been transmitted by the sender party to the receiver") },
                {ReleaseTrigger.Trash, new ReleaseStateTrigger((int)ReleaseTrigger.Trash, "Trash", "The document has been marked for deletion and can no longer be edited or otherwise used.") },
            };


            Statemachine = new StateMachine<ReleaseState, ReleaseTrigger>(state);

            Statemachine.OnTransitionCompleted(OnTransition);
            
            Statemachine.Configure(ReleaseState.P1_Draft)
                .Permit(ReleaseTrigger.Edit, ReleaseState.P1_Edit)
                .Permit(ReleaseTrigger.Trash, ReleaseState.P1_Trash)
                .Permit(ReleaseTrigger.Archive, ReleaseState.P1_Archive)
                .Permit(ReleaseTrigger.Transmit, ReleaseState.P2_Received);

            Statemachine.Configure(ReleaseState.P1_Edit)
                .Permit(ReleaseTrigger.Save, ReleaseState.P1_Draft)
                .Permit(ReleaseTrigger.Trash, ReleaseState.P1_Trash);

            Statemachine.Configure(ReleaseState.P1_Rejected)
               .Permit(ReleaseTrigger.Archive, ReleaseState.P1_Archive)
               .Permit(ReleaseTrigger.Edit, ReleaseState.P1_Edit)
               .Permit(ReleaseTrigger.Trash, ReleaseState.P1_Trash);

            Statemachine.Configure(ReleaseState.P1_Trash);

            Statemachine.Configure(ReleaseState.P2_Received)
                .Permit(ReleaseTrigger.Accept, ReleaseState.P2_Accepted)
                .Permit(ReleaseTrigger.Reject, ReleaseState.P1_Rejected);

            Statemachine.Configure(ReleaseState.P2_Accepted)
                .Permit(ReleaseTrigger.Transmit, ReleaseState.P3_Recieved);

            Statemachine.Configure(ReleaseState.P3_Recieved)
                .Permit(ReleaseTrigger.Reject, ReleaseState.P1_Rejected)
                .Permit(ReleaseTrigger.Accept, ReleaseState.P1_Complete);
        }

        internal ReleaseStateInfo GetStateInfo()
        {
            var permTriggers = this.Statemachine.GetPermittedTriggers();
            var rtnTriggers = new List<ReleaseStateTrigger>();

            foreach (var trigger in permTriggers)
            {
                this.Triggers.TryGetValue(trigger, out var rtn);
                rtnTriggers.Add(rtn);
            }

            return new ReleaseStateInfo { StateId=(int)this.Statemachine.State, AvailableTriggers = rtnTriggers };
        }

        public bool CanFire(ReleaseTrigger trigger)
        {
            return this.Statemachine.CanFire(trigger);
        }

        public void Fire(ReleaseTrigger trigger)
        {
           this.Statemachine.Fire(trigger);
        }

        public ReleaseState State => this.Statemachine.State;

        public string ToDotMap()
        {
            return UmlDotGraph.Format(this.Statemachine.GetInfo());
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ReleaseMachine FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ReleaseMachine>(json);
        }
    }
}
