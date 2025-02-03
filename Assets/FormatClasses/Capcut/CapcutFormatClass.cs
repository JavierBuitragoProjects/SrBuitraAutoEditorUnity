
public class CapcutFormatClass
{
    public Canvas_Config canvas_config { get; set; }
    public long color_space { get; set; }
    public Config config { get; set; }
    public object cover { get; set; }
    public long create_time { get; set; }
    public long duration { get; set; }
    public object extra_info { get; set; }
    public float fps { get; set; }
    public bool free_render_index_mode_on { get; set; }
    public object group_container { get; set; }
    public string id { get; set; }
    public bool is_drop_frame_timecode { get; set; }
    public object[] keyframe_graph_list { get; set; }
    public Keyframes keyframes { get; set; }
    public Last_Modified_Platform last_modified_platform { get; set; }
    public object[] lyrics_effects { get; set; }
    public Materials materials { get; set; }
    public object mutable_config { get; set; }
    public string name { get; set; }
    public string new_version { get; set; }
    public string path { get; set; }
    public Platform platform { get; set; }
    public object[] relationships { get; set; }
    public bool render_index_track_mode_on { get; set; }
    public object retouch_cover { get; set; }
    public string source { get; set; }
    public string static_cover_image_path { get; set; }
    public object time_marks { get; set; }
    public Track[] tracks { get; set; }
    public long update_time { get; set; }
    public long version { get; set; }
}

public class Canvas_Config
{
    public object background { get; set; }
    public long height { get; set; }
    public string ratio { get; set; }
    public long width { get; set; }
}

public class Config
{
    public long adjust_max_index { get; set; }
    public object[] attachment_info { get; set; }
    public long combination_max_index { get; set; }
    public object export_range { get; set; }
    public long extract_audio_last_index { get; set; }
    public string lyrics_recognition_id { get; set; }
    public bool lyrics_sync { get; set; }
    public object[] lyrics_taskinfo { get; set; }
    public bool malongrack_adsorb { get; set; }
    public long material_save_mode { get; set; }
    public string multi_language_current { get; set; }
    public object[] multi_language_list { get; set; }
    public string multi_language_main { get; set; }
    public string multi_language_mode { get; set; }
    public long original_sound_last_index { get; set; }
    public long record_audio_last_index { get; set; }
    public long sticker_max_index { get; set; }
    public object subtitle_keywords_config { get; set; }
    public string subtitle_recognition_id { get; set; }
    public bool subtitle_sync { get; set; }
    public object[] subtitle_taskinfo { get; set; }
    public object[] system_font_list { get; set; }
    public bool video_mute { get; set; }
    public object zoom_info_params { get; set; }
}

public class Keyframes
{
    public object[] adjusts { get; set; }
    public object[] audios { get; set; }
    public object[] effects { get; set; }
    public object[] filters { get; set; }
    public object[] handwrites { get; set; }
    public object[] stickers { get; set; }
    public object[] texts { get; set; }
    public object[] videos { get; set; }
}

public class Last_Modified_Platform
{
    public long app_id { get; set; }
    public string app_source { get; set; }
    public string app_version { get; set; }
    public string device_id { get; set; }
    public string hard_disk_id { get; set; }
    public string mac_address { get; set; }
    public string os { get; set; }
    public string os_version { get; set; }
}

public class Materials
{
    public object[] ai_translates { get; set; }
    public object[] audio_balances { get; set; }
    public object[] audio_effects { get; set; }
    public object[] audio_fades { get; set; }
    public object[] audio_track_indexes { get; set; }
    public object[] audios { get; set; }
    public object[] beats { get; set; }
    public Canvas[] canvases { get; set; }
    public object[] chromas { get; set; }
    public object[] color_curves { get; set; }
    public object[] common_mask { get; set; }
    public object[] digital_humans { get; set; }
    public Drafts[] drafts { get; set; }
    public object[] effects { get; set; }
    public object[] flowers { get; set; }
    public object[] green_screens { get; set; }
    public object[] handwrites { get; set; }
    public object[] hsl { get; set; }
    public object[] images { get; set; }
    public object[] log_color_wheels { get; set; }
    public object[] loudnesses { get; set; }
    public object[] manual_deformations { get; set; }
    public object[] material_animations { get; set; }
    public object[] material_colors { get; set; }
    public object[] multi_language_refs { get; set; }
    public Placeholder_Infos[] placeholder_infos { get; set; }
    public object[] placeholders { get; set; }
    public object[] plugin_effects { get; set; }
    public object[] primary_color_wheels { get; set; }
    public object[] realtime_denoises { get; set; }
    public object[] shapes { get; set; }
    public object[] smart_crops { get; set; }
    public object[] smart_relights { get; set; }
    public Sound_Channel_Mappings[] sound_channel_mappings { get; set; }
    public Speed[] speeds { get; set; }
    public object[] stickers { get; set; }
    public object[] tail_leaders { get; set; }
    public object[] text_templates { get; set; }
    public object[] texts { get; set; }
    public object[] time_marks { get; set; }
    public object[] transitions { get; set; }
    public object[] video_effects { get; set; }
    public object[] video_trackings { get; set; }
    public Video[] videos { get; set; }
    public object[] vocal_beautifys { get; set; }
    public Vocal_Separations[] vocal_separations { get; set; }
}

public class Canvas
{
    public string album_image { get; set; }
    public float blur { get; set; }
    public string color { get; set; }
    public string id { get; set; }
    public string image { get; set; }
    public string image_id { get; set; }
    public string image_name { get; set; }
    public long source_platform { get; set; }
    public string team_id { get; set; }
    public string type { get; set; }
}

public class Drafts
{
    public object aimusic_mv_template_info { get; set; }
    public string category_id { get; set; }
    public string category_name { get; set; }
    public string combination_id { get; set; }
    public string combination_type { get; set; }
    public CapcutFormatClass draft { get; set; }
    public string draft_config_path { get; set; }
    public string draft_cover_path { get; set; }
    public string draft_file_path { get; set; }
    public string formula_id { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public bool precompile_combination { get; set; }
    public string type { get; set; }
}

public class Placeholder_Infos
{
    public string error_path { get; set; }
    public string error_text { get; set; }
    public string id { get; set; }
    public string meta_type { get; set; }
    public string res_path { get; set; }
    public string res_text { get; set; }
    public string type { get; set; }
}

public class Sound_Channel_Mappings
{
    public long audio_channel_mapping { get; set; }
    public string id { get; set; }
    public bool is_config_open { get; set; }
    public string type { get; set; }
}

public class Speed
{
    public object curve_speed { get; set; }
    public string id { get; set; }
    public long mode { get; set; }
    public float speed { get; set; }
    public string type { get; set; }
}

public class Video
{
    public string aigc_history_id { get; set; }
    public string aigc_item_id { get; set; }
    public string aigc_type { get; set; }
    public object audio_fade { get; set; }
    public string beauty_body_preset_id { get; set; }
    public object[] beauty_face_preset_infos { get; set; }
    public string cartoon_path { get; set; }
    public string category_id { get; set; }
    public string category_name { get; set; }
    public long check_flag { get; set; }
    public Crop crop { get; set; }
    public string crop_ratio { get; set; }
    public float crop_scale { get; set; }
    public long duration { get; set; }
    public long extra_type_option { get; set; }
    public string formula_id { get; set; }
    public object freeze { get; set; }
    public bool has_audio { get; set; }
    public bool has_sound_separated { get; set; }
    public long height { get; set; }
    public string id { get; set; }
    public string longensifies_audio_path { get; set; }
    public string longensifies_path { get; set; }
    public bool is_ai_generate_content { get; set; }
    public bool is_copyright { get; set; }
    public bool is_text_edit_overdub { get; set; }
    public bool is_unified_beauty_mode { get; set; }
    public string live_photo_cover_path { get; set; }
    public long live_photo_timestamp { get; set; }
    public string local_id { get; set; }
    public string local_material_from { get; set; }
    public string local_material_id { get; set; }
    public string material_id { get; set; }
    public string material_name { get; set; }
    public string material_url { get; set; }
    public Matting matting { get; set; }
    public string media_path { get; set; }
    public object multi_camera_info { get; set; }
    public object object_locked { get; set; }
    public string origin_material_id { get; set; }
    public string path { get; set; }
    public string picture_from { get; set; }
    public string picture_set_category_id { get; set; }
    public string picture_set_category_name { get; set; }
    public string request_id { get; set; }
    public string reverse_longensifies_path { get; set; }
    public string reverse_path { get; set; }
    public object smart_match_info { get; set; }
    public object smart_motion { get; set; }
    public long source { get; set; }
    public long source_platform { get; set; }
    public Stable stable { get; set; }
    public string team_id { get; set; }
    public string type { get; set; }
    public Video_Algorithm video_algorithm { get; set; }
    public long width { get; set; }
}

public class Crop
{
    public float lower_left_x { get; set; }
    public float lower_left_y { get; set; }
    public float lower_right_x { get; set; }
    public float lower_right_y { get; set; }
    public float upper_left_x { get; set; }
    public float upper_left_y { get; set; }
    public float upper_right_x { get; set; }
    public float upper_right_y { get; set; }
}

public class Matting
{
    public string custom_matting_id { get; set; }
    public long expansion { get; set; }
    public long feather { get; set; }
    public long flag { get; set; }
    public bool has_use_quick_brush { get; set; }
    public bool has_use_quick_eraser { get; set; }
    public object[] longeractiveTime { get; set; }
    public string path { get; set; }
    public bool reverse { get; set; }
    public object[] strokes { get; set; }
}

public class Stable
{
    public string matrix_path { get; set; }
    public long stable_level { get; set; }
    public Time_Range time_range { get; set; }
}

public class Time_Range
{
    public long duration { get; set; }
    public long start { get; set; }
}

public class Video_Algorithm
{
    public object[] ai_background_configs { get; set; }
    public object aigc_generate { get; set; }
    public object[] algorithms { get; set; }
    public object complement_frame_config { get; set; }
    public object deflicker { get; set; }
    public object[] gameplay_configs { get; set; }
    public object motion_blur_config { get; set; }
    public object mouth_shape_driver { get; set; }
    public object noise_reduction { get; set; }
    public string path { get; set; }
    public object quality_enhance { get; set; }
    public object smart_complement_frame { get; set; }
    public object super_resolution { get; set; }
    public object time_range { get; set; }
}

public class Vocal_Separations
{
    public long choice { get; set; }
    public string id { get; set; }
    public string production_path { get; set; }
    public object[] removed_sounds { get; set; }
    public object time_range { get; set; }
    public string type { get; set; }
}

public class Platform
{
    public long app_id { get; set; }
    public string app_source { get; set; }
    public string app_version { get; set; }
    public string device_id { get; set; }
    public string hard_disk_id { get; set; }
    public string mac_address { get; set; }
    public string os { get; set; }
    public string os_version { get; set; }
}

public class Track
{
    public long attribute { get; set; }
    public long flag { get; set; }
    public string id { get; set; }
    public bool is_default_name { get; set; }
    public string name { get; set; }
    public Segment[] segments { get; set; }
    public string type { get; set; }
}

public class Segment
{
    public object caption_info { get; set; }
    public bool cartoon { get; set; }
    public Clip clip { get; set; }
    public object[] common_keyframes { get; set; }
    public string desc { get; set; }
    public bool enable_adjust { get; set; }
    public bool enable_adjust_mask { get; set; }
    public bool enable_color_correct_adjust { get; set; }
    public bool enable_color_curves { get; set; }
    public bool enable_color_match_adjust { get; set; }
    public bool enable_color_wheels { get; set; }
    public bool enable_hsl { get; set; }
    public bool enable_lut { get; set; }
    public bool enable_smart_color_adjust { get; set; }
    public bool enable_video_mask { get; set; }
    public string[] extra_material_refs { get; set; }
    public string group_id { get; set; }
    public Hdr_Settings hdr_settings { get; set; }
    public string id { get; set; }
    public bool longensifies_audio { get; set; }
    public bool is_loop { get; set; }
    public bool is_placeholder { get; set; }
    public bool is_tone_modify { get; set; }
    public object[] keyframe_refs { get; set; }
    public float last_nonzero_volume { get; set; }
    public object lyric_keyframes { get; set; }
    public string material_id { get; set; }
    public string raw_segment_id { get; set; }
    public long render_index { get; set; }
    public Render_Timerange render_timerange { get; set; }
    public Responsive_Layout responsive_layout { get; set; }
    public bool reverse { get; set; }
    public Source_Timerange source_timerange { get; set; }
    public float speed { get; set; }
    public long state { get; set; }
    public Target_Timerange target_timerange { get; set; }
    public string template_id { get; set; }
    public string template_scene { get; set; }
    public long track_attribute { get; set; }
    public long track_render_index { get; set; }
    public Uniform_Scale uniform_scale { get; set; }
    public bool visible { get; set; }
    public float volume { get; set; }
}

public class Clip
{
    public float alpha { get; set; }
    public Flip flip { get; set; }
    public float rotation { get; set; }
    public Scale scale { get; set; }
    public Transform transform { get; set; }
}

public class Flip
{
    public bool horizontal { get; set; }
    public bool vertical { get; set; }
}

public class Scale
{
    public float x { get; set; }
    public float y { get; set; }
}

public class Transform
{
    public float x { get; set; }
    public float y { get; set; }
}

public class Hdr_Settings
{
    public float longensity { get; set; }
    public long mode { get; set; }
    public long nits { get; set; }
}

public class Render_Timerange
{
    public long duration { get; set; }
    public long start { get; set; }
}

public class Responsive_Layout
{
    public bool enable { get; set; }
    public long horizontal_pos_layout { get; set; }
    public long size_layout { get; set; }
    public string target_follow { get; set; }
    public long vertical_pos_layout { get; set; }
}

public class Source_Timerange
{
    public long duration { get; set; }
    public long start { get; set; }
}

public class Target_Timerange
{
    public long duration { get; set; }
    public long start { get; set; }
}

public class Uniform_Scale
{
    public bool on { get; set; }
    public float value { get; set; }
}
