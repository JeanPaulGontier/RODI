# Vanilla JavaScript Fullscreen Lightbox Pro

## Description
A vanilla JavaScript plug-in without production dependencies for displaying images, videos, or, through custom sources, anything you want in a clean overlying box.
The project's website: https://fslightbox.com.

## Basic usage
```html
<a data-fslightbox="gallery" href="https://i.imgur.com/fsyrScY.jpg">
	Open the first slide (an image)
</a>
<a
	data-fslightbox="gallery"
	href="https://www.youtube.com/watch?v=xshEZzpS4CQ"
>
	Open the second slide (a YouTube video)
</a>
<a
	data-fslightbox="gallery"
	href="https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"
>
	Open the third slide (an HTML video)
</a>
<a
	data-fslightbox="gallery"
	href="#vimeo"
>
	Open the fourth slide (a Vimeo video—a custom source)
</a>
<iframe
	id="vimeo"
	src="https://player.vimeo.com/video/22439234"
	width="1920px"
	height="1080px"
	frameBorder="0"
	allow="autoplay; fullscreen"
	allowFullScreen
></iframe>

<script src="fslightbox.js"></script>
```

## Documentation
Available at: https://fslightbox.com/javascript/documentation.

## Browser Compatibility

| Browser | Works? |
| --- | --- |
| Chrome | Yes |
| Firefox | Yes |
| Opera | Yes |
| Safari | Yes |
| Edge | Yes |
| IE 11 | Yes |
