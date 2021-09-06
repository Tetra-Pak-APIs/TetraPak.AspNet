import os
from os.path import join
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


def dump_args():
    args = "".join(sys.argv)
    print(args)


is_verbose = is_flagged('-verbose')
if is_verbose:
    dump_args()


def delete_files(folder):
    if is_verbose:
        print(f'Cleans folder: {folder}')
    existing_files = glob.glob1(folder, name)
    for existing_file in existing_files:
        file_path = join(folder, existing_file)
        os.unlink(file_path)


is_cleaning = is_flagged('-clean')
is_moving = is_flagged('-move')
name = get_arg('-name')
if name is None:
    name = '*'

source = get_arg('-from')
if source is None:
    if is_verbose:
        print('No source folder specified (expected -s <path>)')
    sys.exit(1)

target = get_arg('-to')
if target is None:
    if is_verbose:
        print('No target folder specified (expected -t <path>)')
    sys.exit(1)

if is_cleaning:
    delete_files(target)

files = glob.glob1(source, name)
if len(files) == 0:
    if is_verbose:
        print(f'No files found with pattern "{name}"')
    exit(0)

os.chdir(source)
for file in files:
    if is_moving:
        if is_verbose:
            print(f'Moves file {file}')
        shutil.move(file, target + '/' + file)
        continue

    if is_verbose:
        print(f'Copies file {file}')
    shutil.copy(file, target)

if is_cleaning:
    delete_files(source)
