using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Telegram.Bot.Types.InlineQueryResults.Abstractions;
using Telegram.Bot.Types.InputMessageContents;

namespace Telegram.Bot.Types.InlineQueryResults
{
    /// <summary>
    /// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound).
    /// By default, this animated MPEG-4 file will be sent by the user with optional caption.
    /// Alternatively, you can provide message_text to send it instead of the animation.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InlineQueryResultMpeg4Gif : InlineQueryResult,
                                             ICaptionInlineQueryResult,
                                             IThumbnailUrlInlineQueryResult,
                                             ITitleInlineQueryResult,
                                             IInputMessageContentResult
    {
        /// <summary>
        /// Initializes a new inline query result
        /// </summary>
        public InlineQueryResultMpeg4Gif()
            : base(InlineQueryResultType.Mpeg4Gif)
        { }

        /// <summary>
        /// Initializes a new inline query result
        /// </summary>
        /// <param name="id">Unique identifier of this result</param>
        /// <param name="mpeg4Url">A valid URL for the MP4 file. File size must not exceed 1MB.</param>
        /// <param name="thumbUrl">Url of the thumbnail for the result.</param>
        public InlineQueryResultMpeg4Gif(string id, Uri mpeg4Url, Uri thumbUrl)
            : this()
        {
            Url = mpeg4Url;
            ThumbUrl = thumbUrl;
        }

        /// <summary>
        /// A valid URL for the MP4 file. File size must not exceed 1MB.
        /// </summary>
        [JsonProperty("mpeg4_url", Required = Required.Always)]
        public Uri Url { get; set; }

        /// <inheritdoc />
        [JsonProperty(Required = Required.Always)]
        public Uri ThumbUrl { get; set; }

        /// <summary>
        /// Optional. Video width
        /// </summary>
        [JsonProperty("mpeg4_width", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Width { get; set; }

        /// <summary>
        /// Optional. Video height
        /// </summary>
        [JsonProperty("mpeg4_height", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Height { get; set; }

        /// <summary>
        /// Optional. Duration of the Video
        /// </summary>
        [JsonProperty("mpeg4_duration")]
        public int Duration { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Caption { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; }

        /// <inheritdoc />
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public InputMessageContent InputMessageContent { get; set; }
    }
}
