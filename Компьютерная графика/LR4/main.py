from PIL import Image


def to_grey(img: Image) -> Image:
    for y in range(img.height):
        for x in range(img.width):
            r, g, b = img.getpixel((x, y))
            grey_shade = int(r * 0.3 + g * 0.59 + b * 0.11)
            img.putpixel((x, y), (grey_shade, grey_shade, grey_shade))
    return img


def thresholding(img: Image, threshold) -> Image:
    for y in range(img.height):
        for x in range(img.width):
            r, g, b = img.getpixel((x, y))
            if r * 0.3 + g * 0.59 + b * 0.11 >= threshold:
                img.putpixel((x, y), (255, 255, 255))
            else:
                img.putpixel((x, y), (0, 0, 0))
    return img


def sobel_filter(img: Image) -> Image:
    a = 0
    b = 0.25
    m = ((-1, 0, 1), (-2, 0, 2), (-1, 0, 1))
    new_img = img.copy()
    for y in range(img.height):
        for x in range(img.width):
            luminance = 0
            for i in range(-1, 2):
                for j in range(-1, 2):
                    r, g, b = img.getpixel(((x+i) % img.width, (y+j) % img.height))
                    luminance += (r * 0.3 + g * 0.59 + b * 0.11) * m[i+1][j+1]
            luminance = int(luminance * b + a)
            new_img.putpixel((x, y), (luminance, luminance, luminance))
    return new_img


if __name__ == '__main__':
    img = to_grey(Image.open('static/m1000x1000.jpeg'))
    img.save('static/1.jpeg')
    threshold = int(input('Введите пороговое значение для пороговой обработки: '))
    img = thresholding(Image.open('static/m1000x1000.jpeg'), threshold)
    img.save('static/2.jpeg')
    img = sobel_filter(Image.open('static/m1000x1000.jpeg'))
    img.save('static/3.jpeg')
