using Exiled.API.Features;
using Exiled.Events.EventArgs;
using SeqExiledLogs;
using System;

namespace SCPSLSeqLog
{
    public class EventHandler
    {

        private readonly Plugin _plugin;

        public EventHandler(Plugin plugin) => _plugin = plugin;

        public void OnJoined(JoinedEventArgs ev)
        {
            LogToSeq.Info("Player {Name} ({UserId}) joined the game from IP: {IP}", ev.Player.Nickname, ev.Player.UserId, ev.Player.IPAddress);
        }

        public void OnDied(DiedEventArgs ev)
        {
            Player target = ev.Target;
            Player killer = ev.Killer;
            string killedBy = ev.HitInformations.GetDamageType().name;
            if (killer == null) {
                LogToSeq.Info("Player {TargetName} ({TargetUserId}) died by {KilledBy}", target.Nickname, target.UserId);
            } else
            {
                LogToSeq.Info("Player {TargetName} ({TargetUserId}) died to {KillerName} ({KillerUserId}) using {KilledBy}.",
                    target.Nickname, target.UserId, killer.Nickname, killer.UserId, killedBy);
            }
        }

        public void OnLeft(LeftEventArgs ev)
        {
            LogToSeq.Info("Player {Name} ({UserId}) left the game.", ev.Player.Nickname, ev.Player.UserId);
        }
    }
}
