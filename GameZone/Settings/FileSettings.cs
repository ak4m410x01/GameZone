namespace GameZone.Settings
{
    public static class FileSettings
    {
        public const string ImagesPath = "/assets/images";
        public const string GamesImagesPath = $"{ImagesPath}/games";
        public const string ImageAllowedExtensions = ".jpg,.jpeg,.png";
        public const int ImageMaxAllowedSizeInBytes = 1_048_576;

    }
}
