import pygame
import os
import numpy as np

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
pygame.display.set_caption("М")
sc.fill(WHITE)

FPS = 30
clock = pygame.time.Clock()

c = complex(0, 1)
P = 200  # размер


def line_brezenham(x0, y0, x1, y1):
    x = x0
    y = y0
    dx = x1 - x0
    dy = y1 - y0
    m = dy/dx
    e = m - 1/2
    for i in range(dx):
        if e >= 0:
            y += 1
            e += m - 1
        else:
            e += m
        x += 1
        pygame.draw.circle(sc, BLACK, (x, y), 1)


def draw_line(x1=0, y1=0, x2=0, y2=0):
    dx = x2 - x1
    dy = y2 - y1
    sign_x = 1 if dx > 0 else -1 if dx < 0 else 0
    sign_y = 1 if dy > 0 else -1 if dy < 0 else 0
    if dx < 0: dx = -dx
    if dy < 0: dy = -dy
    if dx > dy:
        pdx, pdy = sign_x, 0
        es, el = dy, dx
    else:
        pdx, pdy = 0, sign_y
        es, el = dx, dy
    x, y = x1, y1
    error, t = el / 2, 0
    pygame.draw.circle(sc, BLACK, (x, y), 1)
    while t < el:
        error -= es
        if error < 0:
            error += el
            x += sign_x
            y += sign_y
        else:
            x += pdx
            y += pdy
        t += 1
        pygame.draw.circle(sc, BLACK, (x, y), 1)


def circle_brezenham(R, x0, y0):
    x = 0
    y = R
    d = 3 - 2*R
    while y >= x:
        pygame.draw.circle(sc, BLACK, (x0 + x, y0 + y), 1)
        pygame.draw.circle(sc, BLACK, (x0 + x, y0 - y), 1)
        pygame.draw.circle(sc, BLACK, (x0 - x, y0 + y), 1)
        pygame.draw.circle(sc, BLACK, (x0 - x, y0 - y), 1)
        pygame.draw.circle(sc, BLACK, (x0 + y, y0 + x), 1)
        pygame.draw.circle(sc, BLACK, (x0 + y, y0 - x), 1)
        pygame.draw.circle(sc, BLACK, (x0 - y, y0 + x), 1)
        pygame.draw.circle(sc, BLACK, (x0 - y, y0 - x), 1)
        if d < 0:
            d += 4*x + 6
        else:
            d += 4*(x-y) + 10
            y -= 1
        x += 1


def bezier(x0, y0, x1, y1, x2, y2):
    pygame.draw.circle(sc, BLACK, (x0, y0), 3)
    pygame.draw.circle(sc, BLACK, (x1, y1), 3)
    pygame.draw.circle(sc, BLACK, (x2, y2), 3)
    t_iter = np.linspace(0, 1, 600)
    for t in t_iter:
        ptx = x0 * (1 - t) ** 2 + x1 * 2 * t * (1 - t) + x2 * t ** 2
        pty = y0 * (1 - t) ** 2 + y1 * 2 * t * (1 - t) + y2 * t ** 2
        pygame.draw.circle(sc, BLACK, (ptx, pty), 1)


def zatravka(x0, y0):
    sc.set_at((x0, y0), (70, 200, 220))
    color = sc.get_at((x0 + 1, y0))
    if color != (0, 0, 0, 255) and color != (70, 200, 220, 255):
        zatravka(x0 + 1, y0)
    color = sc.get_at((x0, y0 + 1))
    if color != (0, 0, 0, 255) and color != (70, 200, 220, 255):
        zatravka(x0, y0 + 1)
    color = sc.get_at((x0 - 1, y0))
    if color != (0, 0, 0, 255) and color != (70, 200, 220, 255):
        zatravka(x0 - 1, y0)
    color = sc.get_at((x0, y0 - 1))
    if color != (0, 0, 0, 255) and color != (70, 200, 220, 255):
        zatravka(x0, y0 - 1)


def koroed(x0, y0):
    stack = list()
    pattern = [[(70, 240, 220, 255), (100, 180, 160, 255)],
               [(210, 80, 90, 255), (160, 140, 200, 255)],
               [(30, 30, 30, 255), (200, 200, 200, 255)]]
    stack.append((x0, y0))
    while len(stack) != 0:
        x, y = stack.pop()
        color = sc.get_at((x, y))
        if color != (0, 0, 0, 255) and color not in pattern[0] and color not in pattern[1] and color not in pattern[2]:
            sc.set_at((x, y), pattern[x % 3][y % 2])
            stack.append((x + 1, y))
            stack.append((x - 1, y))
            stack.append((x, y + 1))
            stack.append((x, y - 1))


while True:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            exit()

    line_brezenham(100, 200, 800, 550)
    line_brezenham(100, 50, 400, 950)
    #draw_line(200, 500, 500, 100)
    circle_brezenham(15, 700, 250)
    bezier(550, 300, 1000, 500, 700, 100)
    bezier(100, 200, 400, 250, 400, 100)
    zatravka(710, 252)
    koroed(200, 220)

    pygame.display.update()
    clock.tick(FPS)

