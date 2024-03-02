import pygame
import os

WHITE = (255, 255, 255)
BLACK = (0, 0, 0)

# ---------- чтобы окно появлялось в верхнем левом углу ------------
x = 20
y = 40
os.environ['SDL_VIDEO_WINDOW_POS'] = "%d,%d" % (x, y)
# --------------------------------------------------------------------

pygame.init()

W = 1200
H = 600

sc = pygame.display.set_mode((W, H))
pygame.display.set_caption("Множества Жулиа")
sc.fill(WHITE)

FPS = 30
clock = pygame.time.Clock()

c = complex(0, 1)
P = 200  # размер
scaleX = P / 1  # масштабный коэффициент
scaleY = P / 1
n_iter = 100  # число итераций для проверки принадлежности к множеству Жулиа

while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            exit()

    for y in range(-P, P):
        for x in range(-P, P):
            a = x / scaleX
            b = y / scaleY
            z = complex(a, b)
            n = 0
            for n in range(n_iter):
                z = z ** 2 + c
                if abs(z) > 2:
                    break

            if n == n_iter - 1:
                r = g = b = 0
            else:
                r = (n % 2) * 32 + 128
                g = (n % 4) * 64
                b = (n % 2) * 16 + 128

            pygame.draw.circle(sc, (r, g, b), (x + P, y + P), 1)
    pygame.display.update()
    clock.tick(FPS)

