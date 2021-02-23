﻿using IdentityServer4.Events;
using RSK.Audit;

namespace RSK.IdentityServer4.AuditEventSink.Adapters
{
    public class ConsentGrantedEventAdapter : IAuditEventArguments
    {
        private readonly ConsentGrantedEvent evt;

        public ConsentGrantedEventAdapter(ConsentGrantedEvent evt)
        {
            this.evt = evt;
        }

        public ResourceActor Actor => new ResourceActor(ResourceActor.UserSubjectType, evt.ClientId, evt.ClientId);
        public string Action => evt.Name;
        public AuditableResource Resource => new AuditableResource("User", evt.SubjectId);
        public FormattedString Description => evt.ToString().SafeForFormatted();
    }
}
