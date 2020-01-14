
-Når man kjører programmet ser man knappen "Admin LoggInn" på høyre siden av start siden.

-Vi har brukt bare en admin, brukernavn: Admin og passord:Admin
			
-Når det gjelder enhetesting(unit testing) av logginnController hadde vi 100% men det minker pga at vi har try 
og catch som IKKE HAR NOE SAMMEHENG MED DATABASEN. Vi innførte try og catch for sending av registrering, endring og sletting av 
strekning og avgang til tre forskjellig text documenter. Alså, det føres ikke noe feil i databasen selv om det viser mindre antall prosent.

-Når det gjelder sending av forskjellig feil(error) til loggen, vi valgte å sende informasjon til loggen,
med en gang man trykker endre eller slette. Altså, hvis endring man prøver å gjøre har gått bra, så kan det sendes 
til loggen at det har skjedd endring, hvis ikke så viser i loggen at man har prøvd å endre noe i listen.

Vi har valgt at endring og sletting av strekning har sin egen logg som heter "StrekningLogg".
Vi har valgt at endring og sletting av avgang har sin egen logg som heter "AvgangLogg".

Når man gjør noe endring kommer lengst ned i dokumentene.