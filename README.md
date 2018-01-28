# GPlatform
A platform style game designed in Unity 5.  For Fun

Known Bugs:
1. Pausing the game using timeScale causes issues with the background music not playing a new song

   Reason: the timer is used to judge the end of the song. But the timer is temporarily paused when the player dies
            the song naturally would continue playing, but the timer is now lagging behind of the song.
            
   Scheduled Patch: TBD
