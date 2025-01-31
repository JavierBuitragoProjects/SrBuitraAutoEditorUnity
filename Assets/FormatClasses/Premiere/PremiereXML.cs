
// NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class PremiereXML
{

    private xmemlSequence sequenceField;

    private byte versionField;

    /// <remarks/>
    public xmemlSequence sequence
    {
        get
        {
            return this.sequenceField;
        }
        set
        {
            this.sequenceField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte version
    {
        get
        {
            return this.versionField;
        }
        set
        {
            this.versionField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequence
{

    private string nameField;

    private byte durationField;

    private xmemlSequenceRate rateField;

    private xmemlSequenceMedia mediaField;

    private bool explodedTracksField;

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public byte duration
    {
        get
        {
            return this.durationField;
        }
        set
        {
            this.durationField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceRate rate
    {
        get
        {
            return this.rateField;
        }
        set
        {
            this.rateField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMedia media
    {
        get
        {
            return this.mediaField;
        }
        set
        {
            this.mediaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public bool explodedTracks
    {
        get
        {
            return this.explodedTracksField;
        }
        set
        {
            this.explodedTracksField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceRate
{

    private byte timebaseField;

    private string ntscField;

    /// <remarks/>
    public byte timebase
    {
        get
        {
            return this.timebaseField;
        }
        set
        {
            this.timebaseField = value;
        }
    }

    /// <remarks/>
    public string ntsc
    {
        get
        {
            return this.ntscField;
        }
        set
        {
            this.ntscField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMedia
{

    private xmemlSequenceMediaVideo videoField;

    private xmemlSequenceMediaAudio audioField;

    /// <remarks/>
    public xmemlSequenceMediaVideo video
    {
        get
        {
            return this.videoField;
        }
        set
        {
            this.videoField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaAudio audio
    {
        get
        {
            return this.audioField;
        }
        set
        {
            this.audioField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideo
{

    private xmemlSequenceMediaVideoFormat formatField;

    private xmemlSequenceMediaVideoClipitem[] trackField;

    /// <remarks/>
    public xmemlSequenceMediaVideoFormat format
    {
        get
        {
            return this.formatField;
        }
        set
        {
            this.formatField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("clipitem", IsNullable = false)]
    public xmemlSequenceMediaVideoClipitem[] track
    {
        get
        {
            return this.trackField;
        }
        set
        {
            this.trackField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoFormat
{

    private xmemlSequenceMediaVideoFormatSamplecharacteristics samplecharacteristicsField;

    /// <remarks/>
    public xmemlSequenceMediaVideoFormatSamplecharacteristics samplecharacteristics
    {
        get
        {
            return this.samplecharacteristicsField;
        }
        set
        {
            this.samplecharacteristicsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoFormatSamplecharacteristics
{

    private ushort widthField;

    private ushort heightField;

    private string pixelaspectratioField;

    private xmemlSequenceMediaVideoFormatSamplecharacteristicsRate rateField;

    /// <remarks/>
    public ushort width
    {
        get
        {
            return this.widthField;
        }
        set
        {
            this.widthField = value;
        }
    }

    /// <remarks/>
    public ushort height
    {
        get
        {
            return this.heightField;
        }
        set
        {
            this.heightField = value;
        }
    }

    /// <remarks/>
    public string pixelaspectratio
    {
        get
        {
            return this.pixelaspectratioField;
        }
        set
        {
            this.pixelaspectratioField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaVideoFormatSamplecharacteristicsRate rate
    {
        get
        {
            return this.rateField;
        }
        set
        {
            this.rateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoFormatSamplecharacteristicsRate
{

    private byte timebaseField;

    private string ntscField;

    /// <remarks/>
    public byte timebase
    {
        get
        {
            return this.timebaseField;
        }
        set
        {
            this.timebaseField = value;
        }
    }

    /// <remarks/>
    public string ntsc
    {
        get
        {
            return this.ntscField;
        }
        set
        {
            this.ntscField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitem
{

    private string nameField;

    private string enabledField;

    private byte startField;

    private byte endField;

    private ushort inField;

    private ushort outField;

    private xmemlSequenceMediaVideoClipitemFile fileField;

    private string compositemodeField;

    private xmemlSequenceMediaVideoClipitemLink[] linkField;

    private string idField;

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string enabled
    {
        get
        {
            return this.enabledField;
        }
        set
        {
            this.enabledField = value;
        }
    }

    /// <remarks/>
    public byte start
    {
        get
        {
            return this.startField;
        }
        set
        {
            this.startField = value;
        }
    }

    /// <remarks/>
    public byte end
    {
        get
        {
            return this.endField;
        }
        set
        {
            this.endField = value;
        }
    }

    /// <remarks/>
    public ushort @in
    {
        get
        {
            return this.inField;
        }
        set
        {
            this.inField = value;
        }
    }

    /// <remarks/>
    public ushort @out
    {
        get
        {
            return this.outField;
        }
        set
        {
            this.outField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFile file
    {
        get
        {
            return this.fileField;
        }
        set
        {
            this.fileField = value;
        }
    }

    /// <remarks/>
    public string compositemode
    {
        get
        {
            return this.compositemodeField;
        }
        set
        {
            this.compositemodeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("link")]
    public xmemlSequenceMediaVideoClipitemLink[] link
    {
        get
        {
            return this.linkField;
        }
        set
        {
            this.linkField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFile
{

    private string nameField;

    private string pathurlField;

    private xmemlSequenceMediaVideoClipitemFileTimecode timecodeField;

    private xmemlSequenceMediaVideoClipitemFileRate rateField;

    private object durationField;

    private xmemlSequenceMediaVideoClipitemFileMedia mediaField;

    private string idField;

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string pathurl
    {
        get
        {
            return this.pathurlField;
        }
        set
        {
            this.pathurlField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileTimecode timecode
    {
        get
        {
            return this.timecodeField;
        }
        set
        {
            this.timecodeField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileRate rate
    {
        get
        {
            return this.rateField;
        }
        set
        {
            this.rateField = value;
        }
    }

    /// <remarks/>
    public object duration
    {
        get
        {
            return this.durationField;
        }
        set
        {
            this.durationField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileMedia media
    {
        get
        {
            return this.mediaField;
        }
        set
        {
            this.mediaField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileTimecode
{

    private string stringField;

    private string displayformatField;

    private xmemlSequenceMediaVideoClipitemFileTimecodeRate rateField;

    /// <remarks/>
    public string @string
    {
        get
        {
            return this.stringField;
        }
        set
        {
            this.stringField = value;
        }
    }

    /// <remarks/>
    public string displayformat
    {
        get
        {
            return this.displayformatField;
        }
        set
        {
            this.displayformatField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileTimecodeRate rate
    {
        get
        {
            return this.rateField;
        }
        set
        {
            this.rateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileTimecodeRate
{

    private byte timebaseField;

    private string ntscField;

    /// <remarks/>
    public byte timebase
    {
        get
        {
            return this.timebaseField;
        }
        set
        {
            this.timebaseField = value;
        }
    }

    /// <remarks/>
    public string ntsc
    {
        get
        {
            return this.ntscField;
        }
        set
        {
            this.ntscField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileRate
{

    private byte timebaseField;

    private string ntscField;

    /// <remarks/>
    public byte timebase
    {
        get
        {
            return this.timebaseField;
        }
        set
        {
            this.timebaseField = value;
        }
    }

    /// <remarks/>
    public string ntsc
    {
        get
        {
            return this.ntscField;
        }
        set
        {
            this.ntscField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileMedia
{

    private xmemlSequenceMediaVideoClipitemFileMediaVideo videoField;

    private xmemlSequenceMediaVideoClipitemFileMediaAudio audioField;

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileMediaVideo video
    {
        get
        {
            return this.videoField;
        }
        set
        {
            this.videoField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileMediaAudio audio
    {
        get
        {
            return this.audioField;
        }
        set
        {
            this.audioField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileMediaVideo
{

    private xmemlSequenceMediaVideoClipitemFileMediaVideoSamplecharacteristics samplecharacteristicsField;

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileMediaVideoSamplecharacteristics samplecharacteristics
    {
        get
        {
            return this.samplecharacteristicsField;
        }
        set
        {
            this.samplecharacteristicsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileMediaVideoSamplecharacteristics
{

    private xmemlSequenceMediaVideoClipitemFileMediaVideoSamplecharacteristicsRate rateField;

    private ushort widthField;

    private ushort heightField;

    private string pixelaspectratioField;

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileMediaVideoSamplecharacteristicsRate rate
    {
        get
        {
            return this.rateField;
        }
        set
        {
            this.rateField = value;
        }
    }

    /// <remarks/>
    public ushort width
    {
        get
        {
            return this.widthField;
        }
        set
        {
            this.widthField = value;
        }
    }

    /// <remarks/>
    public ushort height
    {
        get
        {
            return this.heightField;
        }
        set
        {
            this.heightField = value;
        }
    }

    /// <remarks/>
    public string pixelaspectratio
    {
        get
        {
            return this.pixelaspectratioField;
        }
        set
        {
            this.pixelaspectratioField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileMediaVideoSamplecharacteristicsRate
{

    private byte timebaseField;

    private string ntscField;

    /// <remarks/>
    public byte timebase
    {
        get
        {
            return this.timebaseField;
        }
        set
        {
            this.timebaseField = value;
        }
    }

    /// <remarks/>
    public string ntsc
    {
        get
        {
            return this.ntscField;
        }
        set
        {
            this.ntscField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileMediaAudio
{

    private xmemlSequenceMediaVideoClipitemFileMediaAudioSamplecharacteristics samplecharacteristicsField;

    private byte channelcountField;

    /// <remarks/>
    public xmemlSequenceMediaVideoClipitemFileMediaAudioSamplecharacteristics samplecharacteristics
    {
        get
        {
            return this.samplecharacteristicsField;
        }
        set
        {
            this.samplecharacteristicsField = value;
        }
    }

    /// <remarks/>
    public byte channelcount
    {
        get
        {
            return this.channelcountField;
        }
        set
        {
            this.channelcountField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemFileMediaAudioSamplecharacteristics
{

    private byte depthField;

    private ushort samplerateField;

    /// <remarks/>
    public byte depth
    {
        get
        {
            return this.depthField;
        }
        set
        {
            this.depthField = value;
        }
    }

    /// <remarks/>
    public ushort samplerate
    {
        get
        {
            return this.samplerateField;
        }
        set
        {
            this.samplerateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaVideoClipitemLink
{

    private string linkcliprefField;

    private string mediatypeField;

    private byte trackindexField;

    private byte clipindexField;

    /// <remarks/>
    public string linkclipref
    {
        get
        {
            return this.linkcliprefField;
        }
        set
        {
            this.linkcliprefField = value;
        }
    }

    /// <remarks/>
    public string mediatype
    {
        get
        {
            return this.mediatypeField;
        }
        set
        {
            this.mediatypeField = value;
        }
    }

    /// <remarks/>
    public byte trackindex
    {
        get
        {
            return this.trackindexField;
        }
        set
        {
            this.trackindexField = value;
        }
    }

    /// <remarks/>
    public byte clipindex
    {
        get
        {
            return this.clipindexField;
        }
        set
        {
            this.clipindexField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaAudio
{

    private byte numOutputChannelsField;

    private xmemlSequenceMediaAudioFormat formatField;

    private xmemlSequenceMediaAudioTrack[] trackField;

    /// <remarks/>
    public byte numOutputChannels
    {
        get
        {
            return this.numOutputChannelsField;
        }
        set
        {
            this.numOutputChannelsField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaAudioFormat format
    {
        get
        {
            return this.formatField;
        }
        set
        {
            this.formatField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("track")]
    public xmemlSequenceMediaAudioTrack[] track
    {
        get
        {
            return this.trackField;
        }
        set
        {
            this.trackField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaAudioFormat
{

    private xmemlSequenceMediaAudioFormatSamplecharacteristics samplecharacteristicsField;

    /// <remarks/>
    public xmemlSequenceMediaAudioFormatSamplecharacteristics samplecharacteristics
    {
        get
        {
            return this.samplecharacteristicsField;
        }
        set
        {
            this.samplecharacteristicsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaAudioFormatSamplecharacteristics
{

    private byte depthField;

    private ushort samplerateField;

    /// <remarks/>
    public byte depth
    {
        get
        {
            return this.depthField;
        }
        set
        {
            this.depthField = value;
        }
    }

    /// <remarks/>
    public ushort samplerate
    {
        get
        {
            return this.samplerateField;
        }
        set
        {
            this.samplerateField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaAudioTrack
{

    private byte outputchannelindexField;

    private xmemlSequenceMediaAudioTrackClipitem[] clipitemField;

    private byte currentExplodedTrackIndexField;

    private byte totalExplodedTrackCountField;

    private string premiereTrackTypeField;

    /// <remarks/>
    public byte outputchannelindex
    {
        get
        {
            return this.outputchannelindexField;
        }
        set
        {
            this.outputchannelindexField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("clipitem")]
    public xmemlSequenceMediaAudioTrackClipitem[] clipitem
    {
        get
        {
            return this.clipitemField;
        }
        set
        {
            this.clipitemField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte currentExplodedTrackIndex
    {
        get
        {
            return this.currentExplodedTrackIndexField;
        }
        set
        {
            this.currentExplodedTrackIndexField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public byte totalExplodedTrackCount
    {
        get
        {
            return this.totalExplodedTrackCountField;
        }
        set
        {
            this.totalExplodedTrackCountField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string premiereTrackType
    {
        get
        {
            return this.premiereTrackTypeField;
        }
        set
        {
            this.premiereTrackTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaAudioTrackClipitem
{

    private string nameField;

    private string enabledField;

    private byte startField;

    private byte endField;

    private ushort inField;

    private ushort outField;

    private xmemlSequenceMediaAudioTrackClipitemFile fileField;

    private xmemlSequenceMediaAudioTrackClipitemSourcetrack sourcetrackField;

    private xmemlSequenceMediaAudioTrackClipitemLabels labelsField;

    private string idField;

    private string premiereChannelTypeField;

    /// <remarks/>
    public string name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public string enabled
    {
        get
        {
            return this.enabledField;
        }
        set
        {
            this.enabledField = value;
        }
    }

    /// <remarks/>
    public byte start
    {
        get
        {
            return this.startField;
        }
        set
        {
            this.startField = value;
        }
    }

    /// <remarks/>
    public byte end
    {
        get
        {
            return this.endField;
        }
        set
        {
            this.endField = value;
        }
    }

    /// <remarks/>
    public ushort @in
    {
        get
        {
            return this.inField;
        }
        set
        {
            this.inField = value;
        }
    }

    /// <remarks/>
    public ushort @out
    {
        get
        {
            return this.outField;
        }
        set
        {
            this.outField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaAudioTrackClipitemFile file
    {
        get
        {
            return this.fileField;
        }
        set
        {
            this.fileField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaAudioTrackClipitemSourcetrack sourcetrack
    {
        get
        {
            return this.sourcetrackField;
        }
        set
        {
            this.sourcetrackField = value;
        }
    }

    /// <remarks/>
    public xmemlSequenceMediaAudioTrackClipitemLabels labels
    {
        get
        {
            return this.labelsField;
        }
        set
        {
            this.labelsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string premiereChannelType
    {
        get
        {
            return this.premiereChannelTypeField;
        }
        set
        {
            this.premiereChannelTypeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaAudioTrackClipitemFile
{

    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id
    {
        get
        {
            return this.idField;
        }
        set
        {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaAudioTrackClipitemSourcetrack
{

    private string mediatypeField;

    private byte trackindexField;

    /// <remarks/>
    public string mediatype
    {
        get
        {
            return this.mediatypeField;
        }
        set
        {
            this.mediatypeField = value;
        }
    }

    /// <remarks/>
    public byte trackindex
    {
        get
        {
            return this.trackindexField;
        }
        set
        {
            this.trackindexField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class xmemlSequenceMediaAudioTrackClipitemLabels
{

    private string label2Field;

    /// <remarks/>
    public string label2
    {
        get
        {
            return this.label2Field;
        }
        set
        {
            this.label2Field = value;
        }
    }
}

