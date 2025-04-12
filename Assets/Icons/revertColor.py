# scan all the .png file whose suffix is "_b" in this directory
# generate .png file whose suffix is "_w" and it the corresponding image of file with "_b"

import os
from PIL import Image
import numpy as np
import glob
import re

# revert RGB and reserve A
def revert_color(image_path, save_path):
	# Open the image file
	img = Image.open(image_path).convert("RGBA")
	# Convert the image to a numpy array
	data = np.array(img)
	# Revert the RGB channels and keep the alpha channel unchanged
	data[..., :3] = 255 - data[..., :3]
	# Create a new image from the modified array
	new_img = Image.fromarray(data, "RGBA")
	# Save the new image to the specified path
	new_img.save(save_path)

if __name__ == "__main__":
	# Get the current directory
	current_directory = os.path.dirname(os.path.abspath(__file__))

	# Find all files in the current directory that match the pattern "*_b.png"
	png_files = glob.glob(os.path.join(current_directory, "*_b.png"))

	# Process each file
	for file_path in png_files:
		# Create the new file name by replacing "_b" with "_w"
		new_file_path = re.sub(r"_b\.png$", "_w.png", file_path)
		# Revert the color and save the new image
		revert_color(file_path, new_file_path)