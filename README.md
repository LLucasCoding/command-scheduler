# Command scheduler

## Basic uses
You schedule commands in data.txt with a unix timestamp that gets executes once that timestamp gets met.

## data.txt formatting
The formating is very simple:
The first word is the unix timestamp in seconds... ex. 1715200000 then the rest of it is the command to execute
There is no way to insert comments into the data file, and it does not support line breaks correctly.

### data.txt example (shutdown automation)

    1715200000 shutdown /s /t 0
    1715250000 shutdown /r /t 0
    1715300000 shutdown /s /t 10 /c "Scheduled shutdown"

