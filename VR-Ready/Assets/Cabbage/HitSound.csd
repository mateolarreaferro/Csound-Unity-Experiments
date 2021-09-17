<Cabbage>
form caption("Untitled") size(400, 300), guiMode("queue") pluginId("def1")


button bounds(32, 84, 80, 40) channel("trigger")
hslider bounds(32, 22, 150, 50) channel("freq") range(0,1000, 400, 1, 0.001)
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d -+rtmidi=NULL -M0 -m0d 
</CsOptions>
<CsInstruments>
; Initialize the global variables. 
ksmps = 32
nchnls = 2
0dbfs = 1


instr 1
    kTrig chnget "trigger" //get value of button
    if changed(kTrig) == 1 then
    event "i","PlaySound", 0, .5  //starts in 0 and plays for .5 seconds -> this  is referenced in C#
    endif
endin


instr PlaySound
    prints "Detected\n"
    aEnv expon 1, p3, 0.01
    aSig oscili aEnv, chnget:i("freq")+(1-aEnv)*400
    outs aSig, aSig

endin

</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
;starts instrument 1 and runs it for a week
i1 0 [60*60*24*7] 
</CsScore>
</CsoundSynthesizer>
