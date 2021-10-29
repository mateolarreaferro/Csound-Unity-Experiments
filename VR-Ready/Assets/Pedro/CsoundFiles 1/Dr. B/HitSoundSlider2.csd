<Cabbage>
form caption("HitSoundSlider2") size(400, 300), guiMode("queue") pluginId("def1")

button bounds(30, 22, 80, 40) channel("trigger")
hslider bounds(32, 76, 150, 50) channel("freq") range(40, 4000, 400, 1, 0.001)
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -d
</CsOptions>
<CsInstruments>
; Initialize the global variables. 
ksmps = 32
nchnls = 2
0dbfs = 1


instr 1
    aEnv expon 1, p3, 0.001
    aSig oscili aEnv, chnget:i("freq")*aEnv
    outs aSig, aSig
endin

</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
</CsScore>
</CsoundSynthesizer>
<bsbPanel>
 <label>Widgets</label>
 <objectName/>
 <x>100</x>
 <y>100</y>
 <width>320</width>
 <height>240</height>
 <visible>true</visible>
 <uuid/>
 <bgcolor mode="nobackground">
  <r>255</r>
  <g>255</g>
  <b>255</b>
 </bgcolor>
</bsbPanel>
<bsbPresets>
</bsbPresets>
