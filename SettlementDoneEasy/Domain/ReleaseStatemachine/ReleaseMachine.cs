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
        public EventHandler<ReleaseContext> Transition;
        public StateMachine<ReleaseState, ReleaseTrigger> Statemachine { get; set; }
        private Dictionary<ReleaseState, ReleaseState> StateContext { get; set; } = new Dictionary<ReleaseState, ReleaseState>();
        private ReleaseGlobalContext GlobalContext { get; set; } = new ReleaseGlobalContext();


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

        private void Configure()
        {
            Statemachine = new StateMachine<ReleaseState, ReleaseTrigger>(ReleaseState.P1_Draft);

            Statemachine.OnTransitionCompleted(OnTransition);

            Statemachine.Configure(ReleaseState.P1_Draft)
                .Permit(ReleaseTrigger.Edit, ReleaseState.P1_Edit)
                .Permit(ReleaseTrigger.Trash, ReleaseState.P1_Trash)
                .Permit(ReleaseTrigger.Archive, ReleaseState.P1_Archive)
                .PermitIf(ReleaseTrigger.Transmit, ReleaseState.P2_Received);

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

        public bool CanFire(ReleaseTrigger trigger)
        {
            return this.Statemachine.CanFire(trigger);
        }

        public void Fire(ReleaseTrigger trigger)
        {
           this.Statemachine.Fire(trigger);
        }

        public ReleaseState State => Statemachine.State;

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
