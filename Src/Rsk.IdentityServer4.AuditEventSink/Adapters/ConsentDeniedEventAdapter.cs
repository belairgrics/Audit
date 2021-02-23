﻿using System;
using IdentityServer4.Events;
using RSK.Audit;

namespace RSK.IdentityServer4.AuditEventSink.Adapters
{
    public class ConsentDeniedEventAdapter : IAuditEventArguments
    {
        private readonly ConsentDeniedEvent evt;

        public ConsentDeniedEventAdapter(ConsentDeniedEvent evt)
        {
            this.evt = evt ?? throw new ArgumentNullException(nameof(evt));
        }

        public ResourceActor Actor => new ResourceActor(ResourceActor.MachineSubjectType, evt.ClientId, evt.ClientId);
        public string Action => evt.Name;
        public AuditableResource Resource => new AuditableResource("User", evt.SubjectId);
        public FormattedString Description => evt.ToString().SafeForFormatted();
    }
}
