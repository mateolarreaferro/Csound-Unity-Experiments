<CsoundSynthesizer>
<CsOptions>
-odac
</CsOptions>
<CsInstruments>

sr = 44100
ksmps = 64
nchnls = 2
0dbfs = 1


instr 10 

kGate chnget "gate"
kFreq chnget "freq"
kAmp chnget "amp"

a1 oscil kAmp, kFreq

outs a1*iDry*kGate, a1*iDty*kGate

  vincr gaRevL, aSigL*iRvb
  vincr gaRevR, aSigR*iRvb 

endin

instr Reverb
        denorm gaRevL, gaRevR
aL, aR  freeverb gaRevL, gaRevR, 0.89, 0.25, sr, 0
        outs aL, aR    
        clear gaRevL, gaRevR
endin  


</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
;starts instrument 1 and runs it for a week
i1 0 [60*60*24*7]
i "Reverb" 0 [60*60*24*7] 
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
