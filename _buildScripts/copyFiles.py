import os
import sys
import glob
import shutil


def get_arg(key):
    index = 0
    for item in sys.argv:
        if item != key:
            index += 1
            continue

        if index+1 == len(sys.argv):
            return None

        return sys.argv[index+1]


def is_flagged(key) -> bool:
    for item in sys.argv:
        if item == key:
            return True
    return False


is_moving = is_flagged('-move')
pattern = get_arg('-name')
if pattern is None:
    pattern = '*'

source = get_arg('-from')
if source is None:
    print('No source folder specified (expected -s <path>)')
    sys.exit(1)

target = get_arg('-to')
if target is None:
    print('No target folder specified (expected -t <path>)')
    sys.exit(1)

# files = os.listdir(source)
files = glob.glob1(source, pattern)
if len(files) == 0:
    exit(0)

os.chdir(source)
for file in files:
    if is_moving:
        shutil.move(file, target + '/' + file)
        continue
    shutil.copy(file, target)
