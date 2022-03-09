﻿using System;
using Duende.IdentityServer.Events;
using RSK.Audit;

namespace Rsk.DuendeIdentityServer.AuditEventSink.Adapters
{
    public class TokenIntrospectionFailureEventAdapter : IAuditEventArguments
    {
        private readonly TokenIntrospectionFailureEvent evt;

        public TokenIntrospectionFailureEventAdapter(TokenIntrospectionFailureEvent evt)
        {
            this.evt = evt ?? throw new ArgumentNullException(nameof(evt));
        }

        public ResourceActor Actor => new ResourceActor(ResourceActor.UserSubjectType, evt.ActivityId, evt.ApiName);
        public string Action => evt.Name;
        public AuditableResource Resource => new AuditableResource("IdentityServer", evt.ActivityId);
        public FormattedString Description => evt.ToString().SafeForFormatted();
    }
}